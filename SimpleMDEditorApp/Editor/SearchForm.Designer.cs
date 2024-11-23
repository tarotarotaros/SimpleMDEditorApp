namespace SimpleMDEditorApp.Editor
{
    partial class SearchForm
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
            SearchTextBox = new System.Windows.Forms.TextBox();
            NextSearchButton = new System.Windows.Forms.Button();
            PreviousSearchButton = new System.Windows.Forms.Button();
            CloseButton = new System.Windows.Forms.Button();
            CloseAfterSearchCheckBox = new System.Windows.Forms.CheckBox();
            UpperLowerCheckBox = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // SearchTextBox
            // 
            SearchTextBox.Location = new System.Drawing.Point(12, 12);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new System.Drawing.Size(391, 23);
            SearchTextBox.TabIndex = 0;
            // 
            // NextSearchButton
            // 
            NextSearchButton.Location = new System.Drawing.Point(224, 44);
            NextSearchButton.Name = "NextSearchButton";
            NextSearchButton.Size = new System.Drawing.Size(179, 23);
            NextSearchButton.TabIndex = 1;
            NextSearchButton.Text = "検索（F3）";
            NextSearchButton.UseVisualStyleBackColor = true;
            NextSearchButton.Click += NextSearchButton_Click;
            // 
            // PreviousSearchButton
            // 
            PreviousSearchButton.Location = new System.Drawing.Point(224, 73);
            PreviousSearchButton.Name = "PreviousSearchButton";
            PreviousSearchButton.Size = new System.Drawing.Size(179, 23);
            PreviousSearchButton.TabIndex = 2;
            PreviousSearchButton.Text = "上へ検索（Shift+F3）";
            PreviousSearchButton.UseVisualStyleBackColor = true;
            PreviousSearchButton.Click += PreviousSearchButton_Click;
            // 
            // CloseButton
            // 
            CloseButton.Location = new System.Drawing.Point(224, 112);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new System.Drawing.Size(179, 23);
            CloseButton.TabIndex = 3;
            CloseButton.Text = "閉じる";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // CloseAfterSearchCheckBox
            // 
            CloseAfterSearchCheckBox.AutoSize = true;
            CloseAfterSearchCheckBox.Checked = true;
            CloseAfterSearchCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            CloseAfterSearchCheckBox.Location = new System.Drawing.Point(12, 115);
            CloseAfterSearchCheckBox.Name = "CloseAfterSearchCheckBox";
            CloseAfterSearchCheckBox.Size = new System.Drawing.Size(106, 19);
            CloseAfterSearchCheckBox.TabIndex = 4;
            CloseAfterSearchCheckBox.Text = "検索したら閉じる";
            CloseAfterSearchCheckBox.UseVisualStyleBackColor = true;
            // 
            // UpperLowerCheckBox
            // 
            UpperLowerCheckBox.AutoSize = true;
            UpperLowerCheckBox.Checked = true;
            UpperLowerCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            UpperLowerCheckBox.Location = new System.Drawing.Point(12, 47);
            UpperLowerCheckBox.Name = "UpperLowerCheckBox";
            UpperLowerCheckBox.Size = new System.Drawing.Size(156, 19);
            UpperLowerCheckBox.TabIndex = 5;
            UpperLowerCheckBox.Text = "大文字・小文字を区別する";
            UpperLowerCheckBox.UseVisualStyleBackColor = true;
            // 
            // SearchForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(415, 144);
            ControlBox = false;
            Controls.Add(UpperLowerCheckBox);
            Controls.Add(CloseAfterSearchCheckBox);
            Controls.Add(CloseButton);
            Controls.Add(PreviousSearchButton);
            Controls.Add(NextSearchButton);
            Controls.Add(SearchTextBox);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SearchForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "検索";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Button NextSearchButton;
        private System.Windows.Forms.Button PreviousSearchButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.CheckBox CloseAfterSearchCheckBox;
        private System.Windows.Forms.CheckBox UpperLowerCheckBox;
    }
}