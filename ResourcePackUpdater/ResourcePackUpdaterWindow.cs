using Microsoft.WindowsAPICodePack.Dialogs;
using ResourcePackUpdaterLibrary;

namespace ResourcePackUpdater;

public partial class ResourcePackUpdaterWindow : Form
{
    private readonly ResourcePackUpdaterInst _updater = new();
    
    public ResourcePackUpdaterWindow()
    {
        InitializeComponent();
    }

    /**
     * Browse button for resource pack namespace folder
     */
    private void button1_Click(object sender, EventArgs e)
    {
        var dialog = new CommonOpenFileDialog();
        dialog.IsFolderPicker = true;
        dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        if (dialog.ShowDialog() != CommonFileDialogResult.Ok)
        {
            MessageBox.Show(
                "Error while opening File Explorer", 
                "Error", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Error);
            return;
        }
        
        if (!_updater.SetPath(dialog.FileName))
        {
            MessageBox.Show(
                "The selected directory could not be found", 
                "Warning", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Warning);
            return;
        }
        
        textBox1.Text = dialog.FileName;
        
        MessageBox.Show(
            "Resource pack namespace folder selected", 
            "Success", 
            MessageBoxButtons.OK, 
            MessageBoxIcon.Information);
    }

    private void button2_Click(object sender, EventArgs e)
    {
        _updater.Run(out var res, out var count);

        switch (res)
        {
            case ResourcePackUpdaterInst.Status.Success:
                MessageBox.Show(
                    $"Successfully updated {count} files",
                    "Results",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                break;
            case ResourcePackUpdaterInst.Status.PathNotValid:
                 MessageBox.Show(
                     "Resource pack directory could not be found",
                     "Error",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
                 break;
            case ResourcePackUpdaterInst.Status.ModelsItemPathNotValid:
                 MessageBox.Show(
                     "Models or models/item folder in the resource pack could not be found",
                     "Error",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
                 break;
            case ResourcePackUpdaterInst.Status.UnauthorizedAccessForCreatingDirectory:
                 MessageBox.Show(
                     "Unauthorized access to create items directory in the resource pack",
                     "Error",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
                 break;
            case ResourcePackUpdaterInst.Status.OtherDirectoryError:
                MessageBox.Show(
                    "Some other error occurred while attempting this operation",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}