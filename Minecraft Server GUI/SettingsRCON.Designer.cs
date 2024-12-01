namespace Minecraft_Server_GUI
{
    partial class SettingsRCON
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsRCON));
            saveButton = new Button();
            label1 = new Label();
            ipTextBox = new TextBox();
            label2 = new Label();
            portTextBox = new TextBox();
            label3 = new Label();
            passwordTextBox = new TextBox();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            saveButton.DialogResult = DialogResult.OK;
            saveButton.Location = new Point(147, 277);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 0;
            saveButton.Text = "Сохранить";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 15);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 1;
            label1.Text = "IP";
            // 
            // ipTextBox
            // 
            ipTextBox.Location = new Point(69, 12);
            ipTextBox.Name = "ipTextBox";
            ipTextBox.Size = new Size(100, 23);
            ipTextBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 44);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 1;
            label2.Text = "Порт";
            // 
            // portTextBox
            // 
            portTextBox.Location = new Point(69, 41);
            portTextBox.Name = "portTextBox";
            portTextBox.Size = new Size(100, 23);
            portTextBox.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 73);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 1;
            label3.Text = "Пароль";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(69, 70);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(100, 23);
            passwordTextBox.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(12, 99);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(210, 172);
            textBox1.TabIndex = 3;
            textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // SettingsRCON
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(234, 312);
            Controls.Add(textBox1);
            Controls.Add(passwordTextBox);
            Controls.Add(portTextBox);
            Controls.Add(label3);
            Controls.Add(ipTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(saveButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "SettingsRCON";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Настройки RCON";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button saveButton;
        private Label label1;
        private TextBox ipTextBox;
        private Label label2;
        private TextBox portTextBox;
        private Label label3;
        private TextBox passwordTextBox;
        private TextBox textBox1;
    }
}