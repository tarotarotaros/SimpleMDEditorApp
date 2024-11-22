namespace SimpleMDEditorApp.Setting
{
    partial class SettingForm
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
            EnableAICheckBox = new System.Windows.Forms.CheckBox();
            APIKeyTextBox = new System.Windows.Forms.TextBox();
            OKButton = new System.Windows.Forms.Button();
            CloseButton = new System.Windows.Forms.Button();
            APIKeyLabel = new System.Windows.Forms.Label();
            SaveImageFolderPathTextBox = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            SaveImageFolderPath_OpenFolderDialogButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // EnableAICheckBox
            // 
            EnableAICheckBox.AutoSize = true;
            EnableAICheckBox.Location = new System.Drawing.Point(20, 28);
            EnableAICheckBox.Name = "EnableAICheckBox";
            EnableAICheckBox.Size = new System.Drawing.Size(135, 19);
            EnableAICheckBox.TabIndex = 0;
            EnableAICheckBox.Text = "AI補完（GPT）を使う";
            EnableAICheckBox.UseVisualStyleBackColor = true;
            EnableAICheckBox.CheckedChanged += EnableAICheckBox_CheckedChanged;
            // 
            // APIKeyTextBox
            // 
            APIKeyTextBox.Location = new System.Drawing.Point(112, 53);
            APIKeyTextBox.Name = "APIKeyTextBox";
            APIKeyTextBox.Size = new System.Drawing.Size(545, 23);
            APIKeyTextBox.TabIndex = 2;
            // 
            // OKButton
            // 
            OKButton.Location = new System.Drawing.Point(444, 242);
            OKButton.Name = "OKButton";
            OKButton.Size = new System.Drawing.Size(98, 33);
            OKButton.TabIndex = 6;
            OKButton.Text = "OK";
            OKButton.UseVisualStyleBackColor = true;
            OKButton.Click += OKButton_Click;
            // 
            // CloseButton
            // 
            CloseButton.Location = new System.Drawing.Point(559, 242);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new System.Drawing.Size(98, 33);
            CloseButton.TabIndex = 7;
            CloseButton.Text = "キャンセル";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CancelButton_Click;
            // 
            // APIKeyLabel
            // 
            APIKeyLabel.AutoSize = true;
            APIKeyLabel.Location = new System.Drawing.Point(52, 56);
            APIKeyLabel.Name = "APIKeyLabel";
            APIKeyLabel.Size = new System.Drawing.Size(54, 15);
            APIKeyLabel.TabIndex = 1;
            APIKeyLabel.Text = "APIキー：";
            // 
            // SaveImageFolderPathTextBox
            // 
            SaveImageFolderPathTextBox.Location = new System.Drawing.Point(112, 147);
            SaveImageFolderPathTextBox.Name = "SaveImageFolderPathTextBox";
            SaveImageFolderPathTextBox.ReadOnly = true;
            SaveImageFolderPathTextBox.Size = new System.Drawing.Size(545, 23);
            SaveImageFolderPathTextBox.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(20, 150);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(86, 15);
            label1.TabIndex = 3;
            label1.Text = "画像保存パス：";
            // 
            // SaveImageFolderPath_OpenFolderDialogButton
            // 
            SaveImageFolderPath_OpenFolderDialogButton.Location = new System.Drawing.Point(559, 176);
            SaveImageFolderPath_OpenFolderDialogButton.Name = "SaveImageFolderPath_OpenFolderDialogButton";
            SaveImageFolderPath_OpenFolderDialogButton.Size = new System.Drawing.Size(98, 33);
            SaveImageFolderPath_OpenFolderDialogButton.TabIndex = 5;
            SaveImageFolderPath_OpenFolderDialogButton.Text = "参照";
            SaveImageFolderPath_OpenFolderDialogButton.UseVisualStyleBackColor = true;
            SaveImageFolderPath_OpenFolderDialogButton.Click += SaveImageFolderPath_OpenFolderDialogButton_Click;
            // 
            // SettingForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(665, 283);
            ControlBox = false;
            Controls.Add(SaveImageFolderPath_OpenFolderDialogButton);
            Controls.Add(label1);
            Controls.Add(SaveImageFolderPathTextBox);
            Controls.Add(APIKeyLabel);
            Controls.Add(CloseButton);
            Controls.Add(OKButton);
            Controls.Add(APIKeyTextBox);
            Controls.Add(EnableAICheckBox);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "環境設定";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox EnableAICheckBox;
        private System.Windows.Forms.TextBox APIKeyTextBox;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label APIKeyLabel;
        private System.Windows.Forms.TextBox SaveImageFolderPathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SaveImageFolderPath_OpenFolderDialogButton;
    }
}