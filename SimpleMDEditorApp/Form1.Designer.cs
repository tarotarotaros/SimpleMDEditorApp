using System.Drawing;
using System.Windows.Forms;

namespace SimpleMDEditorApp
{
    partial class EditorForm
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新規作成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開くToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上書き保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.名前を付けて保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.終了ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存して終了ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.編集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.表示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ウィンドウToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.その他ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CharacterCode = new System.Windows.Forms.StatusStrip();
            this.MarkDownWebView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.MarkDownEditTabControl = new System.Windows.Forms.TabControl();
            this.PlainTextTabPage = new System.Windows.Forms.TabPage();
            this.PreviewTabPage = new System.Windows.Forms.TabPage();
            this.EditorTextBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MarkDownWebView)).BeginInit();
            this.MarkDownEditTabControl.SuspendLayout();
            this.PlainTextTabPage.SuspendLayout();
            this.PreviewTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem,
            this.編集ToolStripMenuItem,
            this.表示ToolStripMenuItem,
            this.ウィンドウToolStripMenuItem,
            this.その他ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(846, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新規作成ToolStripMenuItem,
            this.開くToolStripMenuItem,
            this.上書き保存ToolStripMenuItem,
            this.名前を付けて保存ToolStripMenuItem,
            this.toolStripSeparator1,
            this.終了ToolStripMenuItem,
            this.保存して終了ToolStripMenuItem});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ファイルToolStripMenuItem.Text = "ファイル";
            // 
            // 新規作成ToolStripMenuItem
            // 
            this.新規作成ToolStripMenuItem.Name = "新規作成ToolStripMenuItem";
            this.新規作成ToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.新規作成ToolStripMenuItem.Text = "新規作成";
            // 
            // 開くToolStripMenuItem
            // 
            this.開くToolStripMenuItem.Name = "開くToolStripMenuItem";
            this.開くToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.開くToolStripMenuItem.Text = "開く";
            // 
            // 上書き保存ToolStripMenuItem
            // 
            this.上書き保存ToolStripMenuItem.Name = "上書き保存ToolStripMenuItem";
            this.上書き保存ToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.上書き保存ToolStripMenuItem.Text = "上書き保存";
            // 
            // 名前を付けて保存ToolStripMenuItem
            // 
            this.名前を付けて保存ToolStripMenuItem.Name = "名前を付けて保存ToolStripMenuItem";
            this.名前を付けて保存ToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.名前を付けて保存ToolStripMenuItem.Text = "名前を付けて保存";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(158, 6);
            // 
            // 終了ToolStripMenuItem
            // 
            this.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            this.終了ToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.終了ToolStripMenuItem.Text = "終了";
            // 
            // 保存して終了ToolStripMenuItem
            // 
            this.保存して終了ToolStripMenuItem.Name = "保存して終了ToolStripMenuItem";
            this.保存して終了ToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.保存して終了ToolStripMenuItem.Text = "保存して終了";
            // 
            // 編集ToolStripMenuItem
            // 
            this.編集ToolStripMenuItem.Name = "編集ToolStripMenuItem";
            this.編集ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.編集ToolStripMenuItem.Text = "編集";
            // 
            // 表示ToolStripMenuItem
            // 
            this.表示ToolStripMenuItem.Name = "表示ToolStripMenuItem";
            this.表示ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.表示ToolStripMenuItem.Text = "表示";
            // 
            // ウィンドウToolStripMenuItem
            // 
            this.ウィンドウToolStripMenuItem.Name = "ウィンドウToolStripMenuItem";
            this.ウィンドウToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.ウィンドウToolStripMenuItem.Text = "ウィンドウ";
            // 
            // その他ToolStripMenuItem
            // 
            this.その他ToolStripMenuItem.Name = "その他ToolStripMenuItem";
            this.その他ToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.その他ToolStripMenuItem.Text = "その他";
            // 
            // CharacterCode
            // 
            this.CharacterCode.Location = new System.Drawing.Point(0, 554);
            this.CharacterCode.Name = "CharacterCode";
            this.CharacterCode.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.CharacterCode.Size = new System.Drawing.Size(846, 22);
            this.CharacterCode.TabIndex = 2;
            this.CharacterCode.Text = "statusStrip1";
            // 
            // MarkDownWebView
            // 
            this.MarkDownWebView.AllowExternalDrop = false;
            this.MarkDownWebView.BackColor = System.Drawing.Color.White;
            this.MarkDownWebView.CreationProperties = null;
            this.MarkDownWebView.DefaultBackgroundColor = System.Drawing.Color.Transparent;
            this.MarkDownWebView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MarkDownWebView.Location = new System.Drawing.Point(3, 3);
            this.MarkDownWebView.Name = "MarkDownWebView";
            this.MarkDownWebView.Size = new System.Drawing.Size(672, 282);
            this.MarkDownWebView.Source = new System.Uri("file://C:/Users/yamamura/Documents/MyDevelop/SimpleMDEditorApp/SimpleMDEditorApp/" +
        "sample.html", System.UriKind.Absolute);
            this.MarkDownWebView.TabIndex = 3;
            this.MarkDownWebView.ZoomFactor = 1D;
            this.MarkDownWebView.CoreWebView2InitializationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs>(this.webView21_CoreWebView2InitializationCompleted);
            this.MarkDownWebView.NavigationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs>(this.webView21_NavigationCompleted);
            // 
            // MarkDownEditTabControl
            // 
            this.MarkDownEditTabControl.Controls.Add(this.PlainTextTabPage);
            this.MarkDownEditTabControl.Controls.Add(this.PreviewTabPage);
            this.MarkDownEditTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MarkDownEditTabControl.Location = new System.Drawing.Point(0, 24);
            this.MarkDownEditTabControl.Name = "MarkDownEditTabControl";
            this.MarkDownEditTabControl.SelectedIndex = 0;
            this.MarkDownEditTabControl.Size = new System.Drawing.Size(846, 530);
            this.MarkDownEditTabControl.TabIndex = 4;
            // 
            // PlainTextTabPage
            // 
            this.PlainTextTabPage.Controls.Add(this.EditorTextBox);
            this.PlainTextTabPage.Location = new System.Drawing.Point(4, 22);
            this.PlainTextTabPage.Name = "PlainTextTabPage";
            this.PlainTextTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.PlainTextTabPage.Size = new System.Drawing.Size(838, 504);
            this.PlainTextTabPage.TabIndex = 0;
            this.PlainTextTabPage.Text = "テキスト";
            this.PlainTextTabPage.UseVisualStyleBackColor = true;
            // 
            // PreviewTabPage
            // 
            this.PreviewTabPage.Controls.Add(this.MarkDownWebView);
            this.PreviewTabPage.Location = new System.Drawing.Point(4, 22);
            this.PreviewTabPage.Name = "PreviewTabPage";
            this.PreviewTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.PreviewTabPage.Size = new System.Drawing.Size(678, 288);
            this.PreviewTabPage.TabIndex = 1;
            this.PreviewTabPage.Text = "プレビュー";
            this.PreviewTabPage.UseVisualStyleBackColor = true;
            // 
            // EditorTextBox
            // 
            this.EditorTextBox.Location = new System.Drawing.Point(38, 34);
            this.EditorTextBox.Name = "EditorTextBox";
            this.EditorTextBox.Size = new System.Drawing.Size(780, 449);
            this.EditorTextBox.TabIndex = 0;
            this.EditorTextBox.Text = "";
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 576);
            this.Controls.Add(this.MarkDownEditTabControl);
            this.Controls.Add(this.CharacterCode);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("BIZ UDゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EditorForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MarkDownWebView)).EndInit();
            this.MarkDownEditTabControl.ResumeLayout(false);
            this.PlainTextTabPage.ResumeLayout(false);
            this.PreviewTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem ファイルToolStripMenuItem;
        private ToolStripMenuItem 新規作成ToolStripMenuItem;
        private ToolStripMenuItem 開くToolStripMenuItem;
        private ToolStripMenuItem 上書き保存ToolStripMenuItem;
        private ToolStripMenuItem 名前を付けて保存ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem 終了ToolStripMenuItem;
        private ToolStripMenuItem 保存して終了ToolStripMenuItem;
        private ToolStripMenuItem 編集ToolStripMenuItem;
        private ToolStripMenuItem 表示ToolStripMenuItem;
        private ToolStripMenuItem ウィンドウToolStripMenuItem;
        private ToolStripMenuItem その他ToolStripMenuItem;
        private StatusStrip CharacterCode;
        private Microsoft.Web.WebView2.WinForms.WebView2 MarkDownWebView;
        private TabControl MarkDownEditTabControl;
        private TabPage PlainTextTabPage;
        private TabPage PreviewTabPage;
        private RichTextBox EditorTextBox;
    }
}
