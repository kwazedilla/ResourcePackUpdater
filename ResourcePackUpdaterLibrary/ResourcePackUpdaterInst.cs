using System.Text.Json;

namespace ResourcePackUpdaterLibrary;

public class ResourcePackUpdaterInst
{
    private string _assetPath = "";
    private string _namespace = "";

    public enum Status 
    {
        Success,
        PathNotValid,
        ModelsItemPathNotValid,
        UnauthorizedAccessForCreatingDirectory,
        OtherDirectoryError,
    }
    
    public void Run(out Status status, out int count)
    {
        if (!ValidatePath())
        {
            status = Status.PathNotValid;
            count = -1;
            return;
        }

        if (!ValidateModelPathExists())
        {
            status = Status.ModelsItemPathNotValid;
            count = -1;
            return;
        }

        if (!ValidateItemsDirectoryExists())
        {
            try
            {
                CreateItemsDirectory();
            }
            catch (UnauthorizedAccessException)
            {
                status = Status.UnauthorizedAccessForCreatingDirectory;
                count = -1;
                return;
            }
            catch (Exception)
            {
                status = Status.OtherDirectoryError;
                count = -1;
                return;
            }
        }

        var modelPath = Path.Combine(_assetPath, @"models\item");
        var itemPath = Path.Combine(_assetPath, "items");
        
        var modelDirectoryInfo = new DirectoryInfo(modelPath);

        var jsonOptions = new JsonSerializerOptions { IncludeFields = true, WriteIndented = true, IndentSize = 4 };

        var processCount = 0;
        
        foreach (var model in modelDirectoryInfo.GetFiles(".", SearchOption.AllDirectories))
        {
            var extension = Path.GetExtension(model.FullName);
            var modelPointer = model
                .FullName[..^extension.Length] // What is this syntax? Truncates the extension
                .Replace(Path.Combine(_assetPath, @"models\"), "") // Truncates the beginning of the path
                .Replace(@"\", "/"); // Replace backslash with forward slash
            var subDirectoryPath = Path.GetDirectoryName(modelPointer.Replace("item/", ""));
            
            var item = new Item
            {
                Model = new Item.ModelInst
                {
                    Type = "minecraft:model",
                    Model = _namespace + ":" + modelPointer
                }
            };

            if (subDirectoryPath is { Length: > 0 }) Directory.CreateDirectory(Path.Combine(itemPath, subDirectoryPath));

            var stream = File.Create(subDirectoryPath != null ? 
                Path.Combine(itemPath, subDirectoryPath, model.Name) : 
                Path.Combine(itemPath, model.Name));
            
            JsonSerializer.Serialize(stream, item, jsonOptions);
            stream.Close();
            processCount++;
        }
        
        status = Status.Success;
        count = processCount;
    }
    
    public bool SetPath(string path)
    {
        if (!ValidatePath(path)) return false;

        _assetPath = path;
        _namespace = new DirectoryInfo(_assetPath).Name;
        return true;
    }

    private static bool ValidatePath(string path)
    {
        return Directory.Exists(path);
    }

    private bool ValidatePath()
    {
        return _assetPath.Length > 0 && Directory.Exists(_assetPath);
    }

    private bool ValidateModelPathExists()
    {
        return Directory.Exists(Path.Combine(_assetPath, @"models\item"));
    }

    private void CreateItemsDirectory()
    {
        if (!ValidatePath()) return;

        Directory.CreateDirectory(Path.Combine(_assetPath, "items"));
    }

    private bool ValidateItemsDirectoryExists()
    {
        return Directory.Exists(Path.Combine(_assetPath, "items"));
    }

}