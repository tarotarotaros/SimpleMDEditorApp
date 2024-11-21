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
            CancelButton = new System.Windows.Forms.Button();
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
            // 
            // APIKeyTextBox
            // 
            APIKeyTextBox.Location = new System.Drawing.Point(112, 53);
            APIKeyTextBox.Name = "APIKeyTextBox";
            APIKeyTextBox.Size = new System.Drawing.Size(545, 23);
            APIKeyTextBox.TabIndex = 1;
            // 
            // OKButton
            // 
            OKButton.Location = new System.Drawing.Point(302, 242);
            OKButton.Name = "OKButton";
            OKButton.Size = new System.Drawing.Size(98, 33);
            OKButton.TabIndex = 2;
            OKButton.Text = "OK";
            OKButton.UseVisualStyleBackColor = true;
            OKButton.Click += OKButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new System.Drawing.Point(417, 242);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new System.Drawing.Size(98, 33);
            CancelButton.TabIndex = 3;
            CancelButton.Text = "キャンセル";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // APIKeyLabel
            // 
            APIKeyLabel.AutoSize = true;
            APIKeyLabel.Location = new System.Drawing.Point(52, 56);
            APIKeyLabel.Name = "APIKeyLabel";
            APIKeyLabel.Size = new System.Drawing.Size(54, 15);
            APIKeyLabel.TabIndex = 4;
            APIKeyLabel.Text = "APIキー：";
            // 
            // SaveImageFolderPathTextBox
            // 
            SaveImageFolderPathTextBox.Location = new System.Drawing.Point(112, 147);
            SaveImageFolderPathTextBox.Name = "SaveImageFolderPathTextBox";
            SaveImageFolderPathTextBox.ReadOnly = true;
            SaveImageFolderPathTextBox.Size = new System.Drawing.Size(545, 23);
            SaveImageFolderPathTextBox.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(20, 150);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(86, 15);
            label1.TabIndex = 7;
            label1.Text = "画像保存パス：";
            // 
            // SaveImageFolderPath_OpenFolderDialogButton
            // 
            SaveImageFolderPath_OpenFolderDialogButton.Location = new System.Drawing.Point(559, 176);
            SaveImageFolderPath_OpenFolderDialogButton.Name = "SaveImageFolderPath_OpenFolderDialogButton";
            SaveImageFolderPath_OpenFolderDialogButton.Size = new System.Drawing.Size(98, 23);
            SaveImageFolderPath_OpenFolderDialogButton.TabIndex = 8;
            SaveImageFolderPath_OpenFolderDialogButton.Text = "参照";
            SaveImageFolderPath_OpenFolderDialogButton.UseVisualStyleBackColor = true;
            SaveImageFolderPath_OpenFolderDialogButton.Click += SaveImageFolderPath_OpenFolderDialogButton_Click;
            // 
            // SettingForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(669, 287);
            ControlBox = false;
            Controls.Add(SaveImageFolderPath_OpenFolderDialogButton);
            Controls.Add(label1);
            Controls.Add(SaveImageFolderPathTextBox);
            Controls.Add(APIKeyLabel);
            Controls.Add(CancelButton);
            Controls.Add(OKButton);
            Controls.Add(APIKeyTextBox);
            Controls.Add(EnableAICheckBox);
            Name = "SettingForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "設定";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox EnableAICheckBox;
        private System.Windows.Forms.TextBox APIKeyTextBox;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label APIKeyLabel;
        private System.Windows.Forms.TextBox SaveImageFolderPathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SaveImageFolderPath_OpenFolderDialogButton;
    }
}