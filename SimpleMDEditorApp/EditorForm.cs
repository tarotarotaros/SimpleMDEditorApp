using Markdig;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.IO;
using System.Windows.Forms;

namespace SimpleMDEditorApp
{
    public partial class EditorForm : Form
    {
        /// <summary>
        /// 保存済みファイルパス
        /// </summary>
        private string _savedPath;


        private string _originalText;
        
        private bool _isModified;
        
        private readonly TextUtility _textUtility;
        private MdFile _lastSavedMdFile;

        public EditorForm()
        {
            InitializeComponent();
            InitializeAsync();

            _textUtility = new TextUtility();
            _lastSavedMdFile = new MdFile();

            EditorTextBox.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
            RowCountTextBox.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
            //EditorTextBox.Font = new System.Drawing.Font("BIZ UDGothic", 9F);
            //RowCountTextBox.Font = new System.Drawing.Font("BIZ UDGothic", 9F);
        }

        async void InitializeAsync()
        {
            try
            {
                await MarkDownWebView.EnsureCoreWebView2Async(null);
            }
            catch (Exception)
            {
                MessageBox.Show("WebView2ランタイムがインストールされていない可能性があります。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        #region イベント

        private void webView21_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                // どこぞやのURLに遷移
                this.MarkDownWebView.CoreWebView2.Navigate("file://C:/Users/yamamura/Documents/MyDevelop/SimpleMDEditorApp/SimpleMDEditorApp/sample.html");

                // 遷移完了のイベント追加
                this.MarkDownWebView.CoreWebView2.NavigationCompleted += this.webView21_NavigationCompleted;
            }
            else
            {
                // エラー処理
            }
        }

        private void webView21_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// テキストが入力されたら一時保存する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditorTextBox_TextChanged(object sender, EventArgs e)
       {

            // EditorTextBoxのテキストを取得し、HTMLに変換
            string markdownText = EditorTextBox.Text;
            string htmlContent = Markdown.ToHtml(markdownText);

            // HTMLをedittemp.htmlとして保存
            string filePath = Path.Combine(Application.StartupPath, "edittemp.html");
            File.WriteAllText(filePath, htmlContent);


            int lineCount = EditorTextBox.Lines.Length;
            RowCountTextBox.Clear();
            for (int i = 1; i <= lineCount; i++)
            {
                RowCountTextBox.AppendText(i.ToString() + Environment.NewLine);
            }

            // WebViewに表示
            this.MarkDownWebView.CoreWebView2.Navigate(filePath);
        }

        #endregion

        #region メニューイベント

        /// <summary>
        /// 新規作成処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 新規作成_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _savedPath = null;
            EditorTextBox.Text = string.Empty;
        }

        /// <summary>
        /// ファイルを開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ファイルを開く_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Markdown Files (*.md)|*.md";
                openFileDialog.Title = "ファイルを開く";

                // ダイアログでファイルが選択された場合
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _savedPath = openFileDialog.FileName; // ファイルパスを保存
                    LoadFile(_savedPath); // ファイルの内容を読み込んで表示
                }
            }
        }

        /// <summary>
        /// 名前を付けて保存処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 名前を付けて保存_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveInNewFile();
        }

        /// <summary>
        /// 上書き保存する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 上書き保存_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_lastSavedMdFile.IsEmpty())
            {
                SaveInNewFile();
            }
            else
            {
                SaveFile(_lastSavedMdFile.SavedFilePath);
            }
        }

        private void EditorTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // タブキーが押された場合
            if (e.KeyCode == Keys.Tab)
            {
                e.SuppressKeyPress = true; // デフォルトのタブ動作を抑制

                // 半角スペース4文字を挿入
                int insertPosition = EditorTextBox.SelectionStart;
                EditorTextBox.Text = EditorTextBox.Text.Insert(insertPosition, "    ");

                // キャレット（カーソル）を新しい位置に移動
                EditorTextBox.SelectionStart = insertPosition + 4;
            }

            // Enterキーが押された場合
            if (e.KeyCode == Keys.Enter)
            {
                // 現在の行番号を取得
                int currentLineIndex = EditorTextBox.GetLineFromCharIndex(EditorTextBox.SelectionStart);

                if (currentLineIndex >= 0)
                {
                    // 現在の行のテキストを取得
                    string currentLineText = EditorTextBox.Lines[currentLineIndex];

                    // パターンに一致するかどうかを確認
                    string[] patterns = { " - ", " * ", "     - ", "     * " };
                    foreach (string pattern in patterns)
                    {
                        if (currentLineText.StartsWith(pattern))
                        {
                            e.SuppressKeyPress = true; // デフォルトのEnter動作を抑制

                            // 現在のキャレット位置（カーソル）に改行とパターンを挿入
                            int insertPosition = EditorTextBox.SelectionStart;
                            EditorTextBox.Text = EditorTextBox.Text.Insert(insertPosition, Environment.NewLine + pattern);

                            // キャレット（カーソル）を新しい行の末尾に移動
                            EditorTextBox.SelectionStart = insertPosition + Environment.NewLine.Length + pattern.Length;
                            break;
                        }
                    }
                }
            }
        }


        #endregion


        #region 補助メソッド

        private void LoadFile(string path)
        {
            _originalText = File.ReadAllText(_savedPath); // 開いたときの内容を保存
            _lastSavedMdFile.Save(path, _originalText);
            EditorTextBox.Text = _originalText;
            MessageBox.Show("ファイルを読み込みました。", "読み込み完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveFile(string path)
        {
            string markdownText = EditorTextBox.Text;
            File.WriteAllText(path, markdownText);
            _lastSavedMdFile.Save(path, markdownText);
            MessageBox.Show("ファイルが保存されました。", "保存完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveInNewFile()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Markdown Files (*.md)|*.md";
                saveFileDialog.DefaultExt = "md";
                saveFileDialog.Title = "名前を付けて保存";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveFile(saveFileDialog.FileName);
                }
            }
        }

        #endregion
    }
}
