namespace ResourcePackUpdater;

partial class ResourcePackUpdaterWindow
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        groupBox1 = new System.Windows.Forms.GroupBox();
        button1 = new System.Windows.Forms.Button();
        textBox1 = new System.Windows.Forms.TextBox();
        button2 = new System.Windows.Forms.Button();
        groupBox1.SuspendLayout();
        SuspendLayout();
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(button1);
        groupBox1.Controls.Add(textBox1);
        groupBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        groupBox1.Location = new System.Drawing.Point(8, 10);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new System.Drawing.Size(767, 86);
        groupBox1.TabIndex = 0;
        groupBox1.TabStop = false;
        groupBox1.Text = "Selected Resource Pack Namespace Folder";
        // 
        // button1
        // 
        button1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        button1.Location = new System.Drawing.Point(579, 35);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(172, 33);
        button1.TabIndex = 1;
        button1.Text = "Browse";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // textBox1
        // 
        textBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        textBox1.Location = new System.Drawing.Point(15, 35);
        textBox1.Name = "textBox1";
        textBox1.ReadOnly = true;
        textBox1.Size = new System.Drawing.Size(558, 33);
        textBox1.TabIndex = 0;
        // 
        // button2
        // 
        button2.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        button2.Location = new System.Drawing.Point(8, 102);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(767, 64);
        button2.TabIndex = 2;
        button2.Text = "RUN";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // ResourcePackUpdaterWindow
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.Control;
        ClientSize = new System.Drawing.Size(784, 175);
        Controls.Add(button2);
        Controls.Add(groupBox1);
        Location = new System.Drawing.Point(15, 15);
        Text = "Resource Pack Updater by kwazedilla";
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button button2;

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.TextBox textBox1;

    private System.Windows.Forms.GroupBox groupBox1;

    #endregion
}