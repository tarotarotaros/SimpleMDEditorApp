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
            元に戻すctrlZToolStripMenuItem = new ToolStripMenuItem();
            やり直しctrlYToolStripMenuItem = new ToolStripMenuItem();
            表示ToolStripMenuItem = new ToolStripMenuItem();
            ウィンドウToolStripMenuItem = new ToolStripMenuItem();
            その他ToolStripMenuItem = new ToolStripMenuItem();
            設定ToolStripMenuItem = new ToolStripMenuItem();
            CharacterCode = new StatusStrip();
            MarkDownWebView = new Microsoft.Web.WebView2.WinForms.WebView2();
            RowCountPanel = new Panel();
            RowCountTextBox = new CustomRichTextBox();
            EditorPanel = new Panel();
            EditorTextBox = new CustomRichTextBox();
            EditorSplitContainer = new SplitContainer();
            MarkDownViewPanel = new Panel();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MarkDownWebView).BeginInit();
            RowCountPanel.SuspendLayout();
            EditorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)EditorSplitContainer).BeginInit();
            EditorSplitContainer.Panel1.SuspendLayout();
            EditorSplitContainer.Panel2.SuspendLayout();
            EditorSplitContainer.SuspendLayout();
            MarkDownViewPanel.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { ファイルToolStripMenuItem, 編集ToolStripMenuItem, 表示ToolStripMenuItem, ウィンドウToolStripMenuItem, その他ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(943, 24);
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
            新規作成ToolStripMenuItem.Click += NewFile_ToolStripMenuItem_Click;
            // 
            // 開くToolStripMenuItem
            // 
            開くToolStripMenuItem.Name = "開くToolStripMenuItem";
            開くToolStripMenuItem.Size = new Size(161, 22);
            開くToolStripMenuItem.Text = "開く";
            開くToolStripMenuItem.Click += OpenFile_ToolStripMenuItem_Click;
            // 
            // 上書き保存ToolStripMenuItem
            // 
            上書き保存ToolStripMenuItem.Name = "上書き保存ToolStripMenuItem";
            上書き保存ToolStripMenuItem.Size = new Size(161, 22);
            上書き保存ToolStripMenuItem.Text = "上書き保存";
            上書き保存ToolStripMenuItem.Click += OverwriteSave_ToolStripMenuItem_Click;
            // 
            // 名前を付けて保存ToolStripMenuItem
            // 
            名前を付けて保存ToolStripMenuItem.Name = "名前を付けて保存ToolStripMenuItem";
            名前を付けて保存ToolStripMenuItem.Size = new Size(161, 22);
            名前を付けて保存ToolStripMenuItem.Text = "名前を付けて保存";
            名前を付けて保存ToolStripMenuItem.Click += SaveNewFile_ToolStripMenuItem_Click;
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
            編集ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 元に戻すctrlZToolStripMenuItem, やり直しctrlYToolStripMenuItem });
            編集ToolStripMenuItem.Name = "編集ToolStripMenuItem";
            編集ToolStripMenuItem.Size = new Size(43, 20);
            編集ToolStripMenuItem.Text = "編集";
            // 
            // 元に戻すctrlZToolStripMenuItem
            // 
            元に戻すctrlZToolStripMenuItem.Name = "元に戻すctrlZToolStripMenuItem";
            元に戻すctrlZToolStripMenuItem.Size = new Size(180, 22);
            元に戻すctrlZToolStripMenuItem.Text = "元に戻す（ctrl + Z）";
            元に戻すctrlZToolStripMenuItem.Click += undo_ctrlZToolStripMenuItem_Click;
            // 
            // やり直しctrlYToolStripMenuItem
            // 
            やり直しctrlYToolStripMenuItem.Name = "やり直しctrlYToolStripMenuItem";
            やり直しctrlYToolStripMenuItem.Size = new Size(180, 22);
            やり直しctrlYToolStripMenuItem.Text = "やり直し（ctrl + Y）";
            やり直しctrlYToolStripMenuItem.Click += redo_ctrlYToolStripMenuItem_Click;
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
            設定ToolStripMenuItem.Size = new Size(170, 22);
            設定ToolStripMenuItem.Text = "環境設定 (ctrl + E)";
            設定ToolStripMenuItem.Click += Setting_ToolStripMenuItem_Click;
            // 
            // CharacterCode
            // 
            CharacterCode.Location = new Point(0, 546);
            CharacterCode.Name = "CharacterCode";
            CharacterCode.Padding = new Padding(1, 0, 12, 0);
            CharacterCode.Size = new Size(943, 22);
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
            MarkDownWebView.Location = new Point(0, 0);
            MarkDownWebView.Name = "MarkDownWebView";
            MarkDownWebView.Size = new Size(430, 514);
            MarkDownWebView.Source = new System.Uri("file://C:/Users/yamamura/Documents/MyDevelop/SimpleMDEditorApp/SimpleMDEditorApp/sample.html", System.UriKind.Absolute);
            MarkDownWebView.TabIndex = 3;
            MarkDownWebView.ZoomFactor = 1D;
            // 
            // RowCountPanel
            // 
            RowCountPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            RowCountPanel.BorderStyle = BorderStyle.FixedSingle;
            RowCountPanel.Controls.Add(RowCountTextBox);
            RowCountPanel.Location = new Point(3, 3);
            RowCountPanel.Margin = new Padding(0);
            RowCountPanel.Name = "RowCountPanel";
            RowCountPanel.Size = new Size(46, 516);
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
            RowCountTextBox.Size = new Size(44, 514);
            RowCountTextBox.TabIndex = 1;
            RowCountTextBox.Text = "";
            // 
            // EditorPanel
            // 
            EditorPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            EditorPanel.BorderStyle = BorderStyle.FixedSingle;
            EditorPanel.Controls.Add(EditorTextBox);
            EditorPanel.Location = new Point(51, 3);
            EditorPanel.Name = "EditorPanel";
            EditorPanel.Size = new Size(447, 516);
            EditorPanel.TabIndex = 2;
            // 
            // EditorTextBox
            // 
            EditorTextBox.BorderStyle = BorderStyle.None;
            EditorTextBox.Dock = DockStyle.Fill;
            EditorTextBox.EnableAutoDragDrop = true;
            EditorTextBox.Font = new Font("BIZ UDゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point);
            EditorTextBox.Location = new Point(0, 0);
            EditorTextBox.Name = "EditorTextBox";
            EditorTextBox.Size = new Size(445, 514);
            EditorTextBox.TabIndex = 0;
            EditorTextBox.Text = "";
            EditorTextBox.TextChanged += EditorTextBox_TextChanged;
            EditorTextBox.KeyDown += EditorTextBox_KeyDown;
            EditorTextBox.PreviewKeyDown += EditorTextBox_PreviewKeyDown;
            // 
            // EditorSplitContainer
            // 
            EditorSplitContainer.Dock = DockStyle.Fill;
            EditorSplitContainer.IsSplitterFixed = true;
            EditorSplitContainer.Location = new Point(0, 24);
            EditorSplitContainer.Name = "EditorSplitContainer";
            // 
            // EditorSplitContainer.Panel1
            // 
            EditorSplitContainer.Panel1.Controls.Add(EditorPanel);
            EditorSplitContainer.Panel1.Controls.Add(RowCountPanel);
            EditorSplitContainer.Panel1.Padding = new Padding(3);
            // 
            // EditorSplitContainer.Panel2
            // 
            EditorSplitContainer.Panel2.BackColor = Color.Transparent;
            EditorSplitContainer.Panel2.Controls.Add(MarkDownViewPanel);
            EditorSplitContainer.Panel2.Padding = new Padding(3);
            EditorSplitContainer.Size = new Size(943, 522);
            EditorSplitContainer.SplitterDistance = 501;
            EditorSplitContainer.TabIndex = 4;
            // 
            // MarkDownViewPanel
            // 
            MarkDownViewPanel.BorderStyle = BorderStyle.FixedSingle;
            MarkDownViewPanel.Controls.Add(MarkDownWebView);
            MarkDownViewPanel.Dock = DockStyle.Fill;
            MarkDownViewPanel.Location = new Point(3, 3);
            MarkDownViewPanel.Name = "MarkDownViewPanel";
            MarkDownViewPanel.Size = new Size(432, 516);
            MarkDownViewPanel.TabIndex = 4;
            // 
            // EditorForm
            // 
            AutoScaleDimensions = new SizeF(6F, 12F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(943, 568);
            Controls.Add(EditorSplitContainer);
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
            RowCountPanel.ResumeLayout(false);
            EditorPanel.ResumeLayout(false);
            EditorSplitContainer.Panel1.ResumeLayout(false);
            EditorSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)EditorSplitContainer).EndInit();
            EditorSplitContainer.ResumeLayout(false);
            MarkDownViewPanel.ResumeLayout(false);
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
        private CustomRichTextBox EditorTextBox;
        private CustomRichTextBox RowCountTextBox;
        private ToolStripMenuItem 設定ToolStripMenuItem;
        private Panel RowCountPanel;
        private Panel EditorPanel;
        private SplitContainer EditorSplitContainer;
        private Panel MarkDownViewPanel;
        private ToolStripMenuItem 元に戻すctrlZToolStripMenuItem;
        private ToolStripMenuItem やり直しctrlYToolStripMenuItem;
    }
}
