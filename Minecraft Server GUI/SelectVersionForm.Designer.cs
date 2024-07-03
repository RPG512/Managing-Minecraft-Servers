namespace Minecraft_Server_GUI
{
    partial class SelectVersionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectVersionForm));
            groupBox1 = new GroupBox();
            checkBox1 = new CheckBox();
            folderButton = new Button();
            folderTextBox = new TextBox();
            folderBrowserDialog = new FolderBrowserDialog();
            groupBox2 = new GroupBox();
            versionListBox = new ListBox();
            okButton = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(folderButton);
            groupBox1.Controls.Add(folderTextBox);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(364, 76);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Рабочая папка";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(6, 51);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(111, 19);
            checkBox1.TabIndex = 2;
            checkBox1.Text = "Каталог версий";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // folderButton
            // 
            folderButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            folderButton.Location = new Point(328, 22);
            folderButton.Name = "folderButton";
            folderButton.Size = new Size(30, 23);
            folderButton.TabIndex = 1;
            folderButton.Text = "...";
            folderButton.UseVisualStyleBackColor = true;
            folderButton.Click += folderButton_Click;
            // 
            // folderTextBox
            // 
            folderTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            folderTextBox.Location = new Point(6, 22);
            folderTextBox.Name = "folderTextBox";
            folderTextBox.ReadOnly = true;
            folderTextBox.Size = new Size(316, 23);
            folderTextBox.TabIndex = 0;
            folderTextBox.TabStop = false;
            folderTextBox.TextChanged += folderTextBox_TextChanged;
            // 
            // folderBrowserDialog
            // 
            folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(versionListBox);
            groupBox2.Location = new Point(12, 94);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(364, 258);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Выбор версии";
            // 
            // versionListBox
            // 
            versionListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            versionListBox.FormattingEnabled = true;
            versionListBox.ItemHeight = 15;
            versionListBox.Location = new Point(6, 22);
            versionListBox.Name = "versionListBox";
            versionListBox.Size = new Size(352, 229);
            versionListBox.TabIndex = 0;
            versionListBox.SelectedIndexChanged += versionListBox_SelectedIndexChanged;
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            okButton.DialogResult = DialogResult.OK;
            okButton.Location = new Point(301, 358);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 2;
            okButton.Text = "Ок";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // SelectVersionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(388, 393);
            Controls.Add(okButton);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SelectVersionForm";
            Text = "Выберите версию";
            FormClosing += SelectVersionForm_FormClosing;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button folderButton;
        private FolderBrowserDialog folderBrowserDialog;
        private TextBox folderTextBox;
        private GroupBox groupBox2;
        private ListBox versionListBox;
        private CheckBox checkBox1;
        private Button okButton;
    }
}