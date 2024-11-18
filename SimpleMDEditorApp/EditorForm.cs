using Markdig;
using Microsoft.Web.WebView2.Core;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SimpleMDEditorApp
{
    public partial class EditorForm : Form
    {
        private int _altPressCount = 0;       // Altキーの押下回数
        private Timer _altPressTimer;        // Altキー押下の監視タイマー
        private const int AltPressInterval = 500; // Altキー2回押下とみなす間隔 (ms)

        private string _originalText;        
        private readonly TextUtility _textUtility;
        private MdFile _lastSavedMdFile;
        private GPTComplement _gptComplement;
        private ProposalStatus _proposalStatus;

        public EditorForm()
        {
            InitializeComponent();
            InitializeAsync();

            _textUtility = new TextUtility();
            _lastSavedMdFile = new MdFile();
            _gptComplement = new GPTComplement();
            _proposalStatus = new ProposalStatus(ProposalStatusType.None, string.Empty);

            EditorTextBox.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
            RowCountTextBox.LanguageOption = RichTextBoxLanguageOptions.UIFonts;

            _altPressTimer = new Timer();
            _altPressTimer.Interval = AltPressInterval;
            _altPressTimer.Tick += (s, e) =>
            {
                // タイマーが発火したらカウントリセット
                _altPressCount = 0;
                _altPressTimer.Stop();
            };
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
                this.MarkDownWebView.CoreWebView2.Navigate("./sample.html");

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
            _lastSavedMdFile = new MdFile();
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
                    LoadFile(openFileDialog.FileName); // ファイルの内容を読み込んで表示
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
            if (_proposalStatus.Type == ProposalStatusType.Proposal)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.EditorTextBox.Select(0, this.EditorTextBox.Text.Length);
                    this.EditorTextBox.SelectionColor = Color.Black;
                    this.EditorTextBox.Select(EditorTextBox.Text.Length, 0);
                }
                else
                {
                    this.RemoveStringFromEnd(_proposalStatus.ProposalText);
                    this.EditorTextBox.Select(EditorTextBox.Text.Length, 0);
                }
                _proposalStatus = new ProposalStatus(ProposalStatusType.None, string.Empty);
            }


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

            // Altキーの監視
            if (e.KeyCode == Keys.Menu) // AltキーはKeys.Menuで検知
            {
                _altPressCount++;

                // タイマーを再スタート
                _altPressTimer.Stop();
                _altPressTimer.Start();

                // Altキーが2回押されたら処理を実行
                if (_altPressCount == 2)
                {
                    HandleDoubleAltPress();
                    _altPressCount = 0; // カウントリセット
                    _altPressTimer.Stop();
                }

                // Altキーのデフォルト動作を無効化しない（必要に応じて変更）
                e.Handled = true;
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

        private async void HandleDoubleAltPress()
        {
            await _gptComplement.TalkAsyncForSingle(EditorTextBox.Text);
            FetchGPTResult();
        }


        #endregion


        #region 補助メソッド

        /// <summary>
        /// ファイルを読み込み
        /// </summary>
        /// <param name="path"></param>
        private void LoadFile(string path)
        {
            _originalText = File.ReadAllText(path); // 開いたときの内容を保存
            _lastSavedMdFile.Save(path, _originalText);
            EditorTextBox.Text = _originalText;
            MessageBox.Show("ファイルを読み込みました。", "読み込み完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// ファイルを保存
        /// </summary>
        /// <param name="path"></param>
        private void SaveFile(string path)
        {
            string markdownText = EditorTextBox.Text;
            File.WriteAllText(path, markdownText);
            _lastSavedMdFile.Save(path, markdownText);
            MessageBox.Show("ファイルが保存されました。", "保存完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 新しいファイルとして保存
        /// </summary>
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

        /// <summary>
        /// テキストのカラーを追加して変更する
        /// </summary>
        /// <param name="richTextBox"></param>
        /// <param name="addText"></param>
        private void ChageCharacterColor(RichTextBox richTextBox, string addText)
        {
            // RichTextBoxにテキストを設定
            richTextBox.Text += addText;

            int startIndex = richTextBox.Text.LastIndexOf(addText);

            if (startIndex != -1)
            {

                // 文字列を選択
                richTextBox.Select(startIndex, addText.Length);

                // 選択した文字列の色を変更
                richTextBox.SelectionColor = Color.Gray;

                // 選択を解除（カーソルを末尾に戻す）
                richTextBox.Select(richTextBox.Text.Length, 0);

                _proposalStatus = new ProposalStatus(ProposalStatusType.Proposal, addText);
            }

        }

        /// <summary>
        // 指定した文字列を末尾から取り除く関数
        /// </summary>
        /// <param name="removeString"></param>
        private void RemoveStringFromEnd(string removeString)
        {
            // 現在のテキスト
            string currentText = EditorTextBox.Text;

            // 末尾が指定文字列と一致する場合
            if (currentText.EndsWith(removeString))
            {
                // 指定文字列を取り除いたテキストを設定
                EditorTextBox.Text = currentText.Substring(0, currentText.Length - removeString.Length);
            }
        }

        /// <summary>
        /// AIからの結果を反映させます。
        /// </summary>
        private void FetchGPTResult()
        {
            while (true)
            {
                if (_gptComplement.Result.GptResultType == GptResultType.Success)
                {
                    ChageCharacterColor(this.EditorTextBox, _gptComplement.Result.ResultText);
                    return;
                }
            }
        }

        #endregion
    }
}
