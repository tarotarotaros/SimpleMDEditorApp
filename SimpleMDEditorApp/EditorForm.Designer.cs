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
            menuStrip1 = new MenuStrip();
            ファイルToolStripMenuItem = new ToolStripMenuItem();
            新規作成ToolStripMenuItem = new ToolStripMenuItem();
            開くToolStripMenuItem = new ToolStripMenuItem();
            上書き保存ToolStripMenuItem = new ToolStripMenuItem();
            名前を付けて保存ToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            終了ToolStripMenuItem = new ToolStripMenuItem();
            保存して終了ToolStripMenuItem = new ToolStripMenuItem();
            編集ToolStripMenuItem = new ToolStripMenuItem();
            表示ToolStripMenuItem = new ToolStripMenuItem();
            ウィンドウToolStripMenuItem = new ToolStripMenuItem();
            その他ToolStripMenuItem = new ToolStripMenuItem();
            設定ToolStripMenuItem = new ToolStripMenuItem();
            CharacterCode = new StatusStrip();
            MarkDownWebView = new Microsoft.Web.WebView2.WinForms.WebView2();
            MarkDownEditTabControl = new TabControl();
            PlainTextTabPage = new TabPage();
            RowCountPanel = new Panel();
            RowCountTextBox = new CustomRichTextBox();
            EditorPanel = new Panel();
            EditorTextBox = new CustomRichTextBox();
            PreviewTabPage = new TabPage();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MarkDownWebView).BeginInit();
            MarkDownEditTabControl.SuspendLayout();
            PlainTextTabPage.SuspendLayout();
            RowCountPanel.SuspendLayout();
            EditorPanel.SuspendLayout();
            PreviewTabPage.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { ファイルToolStripMenuItem, 編集ToolStripMenuItem, 表示ToolStripMenuItem, ウィンドウToolStripMenuItem, その他ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(589, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            ファイルToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 新規作成ToolStripMenuItem, 開くToolStripMenuItem, 上書き保存ToolStripMenuItem, 名前を付けて保存ToolStripMenuItem, toolStripSeparator1, 終了ToolStripMenuItem, 保存して終了ToolStripMenuItem });
            ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            ファイルToolStripMenuItem.Size = new Size(53, 20);
            ファイルToolStripMenuItem.Text = "ファイル";
            // 
            // 新規作成ToolStripMenuItem
            // 
            新規作成ToolStripMenuItem.Name = "新規作成ToolStripMenuItem";
            新規作成ToolStripMenuItem.Size = new Size(161, 22);
            新規作成ToolStripMenuItem.Text = "新規作成";
            新規作成ToolStripMenuItem.Click += 新規作成_ToolStripMenuItem_Click;
            // 
            // 開くToolStripMenuItem
            // 
            開くToolStripMenuItem.Name = "開くToolStripMenuItem";
            開くToolStripMenuItem.Size = new Size(161, 22);
            開くToolStripMenuItem.Text = "開く";
            開くToolStripMenuItem.Click += ファイルを開く_ToolStripMenuItem_Click;
            // 
            // 上書き保存ToolStripMenuItem
            // 
            上書き保存ToolStripMenuItem.Name = "上書き保存ToolStripMenuItem";
            上書き保存ToolStripMenuItem.Size = new Size(161, 22);
            上書き保存ToolStripMenuItem.Text = "上書き保存";
            上書き保存ToolStripMenuItem.Click += 上書き保存_ToolStripMenuItem_Click;
            // 
            // 名前を付けて保存ToolStripMenuItem
            // 
            名前を付けて保存ToolStripMenuItem.Name = "名前を付けて保存ToolStripMenuItem";
            名前を付けて保存ToolStripMenuItem.Size = new Size(161, 22);
            名前を付けて保存ToolStripMenuItem.Text = "名前を付けて保存";
            名前を付けて保存ToolStripMenuItem.Click += 名前を付けて保存_ToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(158, 6);
            // 
            // 終了ToolStripMenuItem
            // 
            終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            終了ToolStripMenuItem.Size = new Size(161, 22);
            終了ToolStripMenuItem.Text = "終了";
            // 
            // 保存して終了ToolStripMenuItem
            // 
            保存して終了ToolStripMenuItem.Name = "保存して終了ToolStripMenuItem";
            保存して終了ToolStripMenuItem.Size = new Size(161, 22);
            保存して終了ToolStripMenuItem.Text = "保存して終了";
            // 
            // 編集ToolStripMenuItem
            // 
            編集ToolStripMenuItem.Name = "編集ToolStripMenuItem";
            編集ToolStripMenuItem.Size = new Size(43, 20);
            編集ToolStripMenuItem.Text = "編集";
            // 
            // 表示ToolStripMenuItem
            // 
            表示ToolStripMenuItem.Name = "表示ToolStripMenuItem";
            表示ToolStripMenuItem.Size = new Size(43, 20);
            表示ToolStripMenuItem.Text = "表示";
            // 
            // ウィンドウToolStripMenuItem
            // 
            ウィンドウToolStripMenuItem.Name = "ウィンドウToolStripMenuItem";
            ウィンドウToolStripMenuItem.Size = new Size(61, 20);
            ウィンドウToolStripMenuItem.Text = "ウィンドウ";
            // 
            // その他ToolStripMenuItem
            // 
            その他ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 設定ToolStripMenuItem });
            その他ToolStripMenuItem.Name = "その他ToolStripMenuItem";
            その他ToolStripMenuItem.Size = new Size(50, 20);
            その他ToolStripMenuItem.Text = "その他";
            // 
            // 設定ToolStripMenuItem
            // 
            設定ToolStripMenuItem.Name = "設定ToolStripMenuItem";
            設定ToolStripMenuItem.Size = new Size(98, 22);
            設定ToolStripMenuItem.Text = "設定";
            設定ToolStripMenuItem.Click += 設定ToolStripMenuItem_Click;
            // 
            // CharacterCode
            // 
            CharacterCode.Location = new Point(0, 457);
            CharacterCode.Name = "CharacterCode";
            CharacterCode.Padding = new Padding(1, 0, 12, 0);
            CharacterCode.Size = new Size(589, 22);
            CharacterCode.TabIndex = 2;
            CharacterCode.Text = "statusStrip1";
            // 
            // MarkDownWebView
            // 
            MarkDownWebView.AllowExternalDrop = false;
            MarkDownWebView.BackColor = Color.White;
            MarkDownWebView.CreationProperties = null;
            MarkDownWebView.DefaultBackgroundColor = Color.Transparent;
            MarkDownWebView.Dock = DockStyle.Fill;
            MarkDownWebView.Location = new Point(3, 3);
            MarkDownWebView.Name = "MarkDownWebView";
            MarkDownWebView.Size = new Size(575, 399);
            MarkDownWebView.Source = new System.Uri("file://C:/Users/yamamura/Documents/MyDevelop/SimpleMDEditorApp/SimpleMDEditorApp/sample.html", System.UriKind.Absolute);
            MarkDownWebView.TabIndex = 3;
            MarkDownWebView.ZoomFactor = 1D;
            MarkDownWebView.CoreWebView2InitializationCompleted += webView21_CoreWebView2InitializationCompleted;
            // 
            // MarkDownEditTabControl
            // 
            MarkDownEditTabControl.Controls.Add(PlainTextTabPage);
            MarkDownEditTabControl.Controls.Add(PreviewTabPage);
            MarkDownEditTabControl.Dock = DockStyle.Fill;
            MarkDownEditTabControl.Location = new Point(0, 24);
            MarkDownEditTabControl.Name = "MarkDownEditTabControl";
            MarkDownEditTabControl.SelectedIndex = 0;
            MarkDownEditTabControl.Size = new Size(589, 433);
            MarkDownEditTabControl.TabIndex = 4;
            // 
            // PlainTextTabPage
            // 
            PlainTextTabPage.Controls.Add(RowCountPanel);
            PlainTextTabPage.Controls.Add(EditorPanel);
            PlainTextTabPage.Location = new Point(4, 22);
            PlainTextTabPage.Name = "PlainTextTabPage";
            PlainTextTabPage.Padding = new Padding(3);
            PlainTextTabPage.Size = new Size(581, 407);
            PlainTextTabPage.TabIndex = 0;
            PlainTextTabPage.Text = "テキスト";
            PlainTextTabPage.UseVisualStyleBackColor = true;
            // 
            // RowCountPanel
            // 
            RowCountPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            RowCountPanel.BorderStyle = BorderStyle.FixedSingle;
            RowCountPanel.Controls.Add(RowCountTextBox);
            RowCountPanel.Location = new Point(3, 3);
            RowCountPanel.Name = "RowCountPanel";
            RowCountPanel.Size = new Size(40, 400);
            RowCountPanel.TabIndex = 3;
            // 
            // RowCountTextBox
            // 
            RowCountTextBox.BorderStyle = BorderStyle.None;
            RowCountTextBox.Dock = DockStyle.Fill;
            RowCountTextBox.Font = new Font("BIZ UDゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point);
            RowCountTextBox.Location = new Point(0, 0);
            RowCountTextBox.Name = "RowCountTextBox";
            RowCountTextBox.ReadOnly = true;
            RowCountTextBox.Size = new Size(38, 398);
            RowCountTextBox.TabIndex = 1;
            RowCountTextBox.Text = "";
            // 
            // EditorPanel
            // 
            EditorPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            EditorPanel.BorderStyle = BorderStyle.FixedSingle;
            EditorPanel.Controls.Add(EditorTextBox);
            EditorPanel.Location = new Point(48, 3);
            EditorPanel.Name = "EditorPanel";
            EditorPanel.Size = new Size(533, 400);
            EditorPanel.TabIndex = 2;
            // 
            // EditorTextBox
            // 
            EditorTextBox.BorderStyle = BorderStyle.None;
            EditorTextBox.Dock = DockStyle.Fill;
            EditorTextBox.Font = new Font("BIZ UDゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point);
            EditorTextBox.Location = new Point(0, 0);
            EditorTextBox.Name = "EditorTextBox";
            EditorTextBox.Size = new Size(531, 398);
            EditorTextBox.TabIndex = 0;
            EditorTextBox.Text = "";
            EditorTextBox.TextChanged += EditorTextBox_TextChanged;
            EditorTextBox.KeyDown += EditorTextBox_KeyDown;
            // 
            // PreviewTabPage
            // 
            PreviewTabPage.Controls.Add(MarkDownWebView);
            PreviewTabPage.Location = new Point(4, 24);
            PreviewTabPage.Name = "PreviewTabPage";
            PreviewTabPage.Padding = new Padding(3);
            PreviewTabPage.Size = new Size(581, 405);
            PreviewTabPage.TabIndex = 1;
            PreviewTabPage.Text = "プレビュー";
            PreviewTabPage.UseVisualStyleBackColor = true;
            // 
            // EditorForm
            // 
            AutoScaleDimensions = new SizeF(6F, 12F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 479);
            Controls.Add(MarkDownEditTabControl);
            Controls.Add(CharacterCode);
            Controls.Add(menuStrip1);
            Font = new Font("BIZ UDゴシック", 9F, FontStyle.Regular, GraphicsUnit.Point);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            Name = "EditorForm";
            Text = "SimpleMDEditorForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)MarkDownWebView).EndInit();
            MarkDownEditTabControl.ResumeLayout(false);
            PlainTextTabPage.ResumeLayout(false);
            RowCountPanel.ResumeLayout(false);
            EditorPanel.ResumeLayout(false);
            PreviewTabPage.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private CustomRichTextBox EditorTextBox;
        private CustomRichTextBox RowCountTextBox;
        private ToolStripMenuItem 設定ToolStripMenuItem;
        private Panel RowCountPanel;
        private Panel EditorPanel;
    }
}
