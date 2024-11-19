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
            SuspendLayout();
            // 
            // EnableAICheckBox
            // 
            EnableAICheckBox.AutoSize = true;
            EnableAICheckBox.Location = new System.Drawing.Point(32, 22);
            EnableAICheckBox.Name = "EnableAICheckBox";
            EnableAICheckBox.Size = new System.Drawing.Size(135, 19);
            EnableAICheckBox.TabIndex = 0;
            EnableAICheckBox.Text = "AI補完（GPT）を使う";
            EnableAICheckBox.UseVisualStyleBackColor = true;
            // 
            // APIKeyTextBox
            // 
            APIKeyTextBox.Location = new System.Drawing.Point(92, 53);
            APIKeyTextBox.Name = "APIKeyTextBox";
            APIKeyTextBox.Size = new System.Drawing.Size(396, 23);
            APIKeyTextBox.TabIndex = 1;
            // 
            // OKButton
            // 
            OKButton.Location = new System.Drawing.Point(289, 114);
            OKButton.Name = "OKButton";
            OKButton.Size = new System.Drawing.Size(98, 33);
            OKButton.TabIndex = 2;
            OKButton.Text = "OK";
            OKButton.UseVisualStyleBackColor = true;
            OKButton.Click += OKButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new System.Drawing.Point(404, 114);
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
            APIKeyLabel.Location = new System.Drawing.Point(32, 56);
            APIKeyLabel.Name = "APIKeyLabel";
            APIKeyLabel.Size = new System.Drawing.Size(54, 15);
            APIKeyLabel.TabIndex = 4;
            APIKeyLabel.Text = "APIキー：";
            // 
            // SettingForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(527, 168);
            ControlBox = false;
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
    }
}