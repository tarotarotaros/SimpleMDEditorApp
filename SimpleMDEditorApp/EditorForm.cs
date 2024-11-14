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
        /// �ۑ��ς݃t�@�C���p�X
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
                MessageBox.Show("WebView2�����^�C�����C���X�g�[������Ă��Ȃ��\��������܂��B", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        #region �C�x���g

        private void webView21_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                // �ǂ������URL�ɑJ��
                this.MarkDownWebView.CoreWebView2.Navigate("file://C:/Users/yamamura/Documents/MyDevelop/SimpleMDEditorApp/SimpleMDEditorApp/sample.html");

                // �J�ڊ����̃C�x���g�ǉ�
                this.MarkDownWebView.CoreWebView2.NavigationCompleted += this.webView21_NavigationCompleted;
            }
            else
            {
                // �G���[����
            }
        }

        private void webView21_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// �e�L�X�g�����͂��ꂽ��ꎞ�ۑ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditorTextBox_TextChanged(object sender, EventArgs e)
       {

            // EditorTextBox�̃e�L�X�g���擾���AHTML�ɕϊ�
            string markdownText = EditorTextBox.Text;
            string htmlContent = Markdown.ToHtml(markdownText);

            // HTML��edittemp.html�Ƃ��ĕۑ�
            string filePath = Path.Combine(Application.StartupPath, "edittemp.html");
            File.WriteAllText(filePath, htmlContent);


            int lineCount = EditorTextBox.Lines.Length;
            RowCountTextBox.Clear();
            for (int i = 1; i <= lineCount; i++)
            {
                RowCountTextBox.AppendText(i.ToString() + Environment.NewLine);
            }

            // WebView�ɕ\��
            this.MarkDownWebView.CoreWebView2.Navigate(filePath);
        }

        #endregion

        #region ���j���[�C�x���g

        /// <summary>
        /// �V�K�쐬����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void �V�K�쐬_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _savedPath = null;
            EditorTextBox.Text = string.Empty;
        }

        /// <summary>
        /// �t�@�C�����J��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void �t�@�C�����J��_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Markdown Files (*.md)|*.md";
                openFileDialog.Title = "�t�@�C�����J��";

                // �_�C�A���O�Ńt�@�C�����I�����ꂽ�ꍇ
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _savedPath = openFileDialog.FileName; // �t�@�C���p�X��ۑ�
                    LoadFile(_savedPath); // �t�@�C���̓��e��ǂݍ���ŕ\��
                }
            }
        }

        /// <summary>
        /// ���O��t���ĕۑ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ���O��t���ĕۑ�_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveInNewFile();
        }

        /// <summary>
        /// �㏑���ۑ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void �㏑���ۑ�_ToolStripMenuItem_Click(object sender, EventArgs e)
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
            // �^�u�L�[�������ꂽ�ꍇ
            if (e.KeyCode == Keys.Tab)
            {
                e.SuppressKeyPress = true; // �f�t�H���g�̃^�u�����}��

                // ���p�X�y�[�X4������}��
                int insertPosition = EditorTextBox.SelectionStart;
                EditorTextBox.Text = EditorTextBox.Text.Insert(insertPosition, "    ");

                // �L�����b�g�i�J�[�\���j��V�����ʒu�Ɉړ�
                EditorTextBox.SelectionStart = insertPosition + 4;
            }

            // Enter�L�[�������ꂽ�ꍇ
            if (e.KeyCode == Keys.Enter)
            {
                // ���݂̍s�ԍ����擾
                int currentLineIndex = EditorTextBox.GetLineFromCharIndex(EditorTextBox.SelectionStart);

                if (currentLineIndex >= 0)
                {
                    // ���݂̍s�̃e�L�X�g���擾
                    string currentLineText = EditorTextBox.Lines[currentLineIndex];

                    // �p�^�[���Ɉ�v���邩�ǂ������m�F
                    string[] patterns = { " - ", " * ", "     - ", "     * " };
                    foreach (string pattern in patterns)
                    {
                        if (currentLineText.StartsWith(pattern))
                        {
                            e.SuppressKeyPress = true; // �f�t�H���g��Enter�����}��

                            // ���݂̃L�����b�g�ʒu�i�J�[�\���j�ɉ��s�ƃp�^�[����}��
                            int insertPosition = EditorTextBox.SelectionStart;
                            EditorTextBox.Text = EditorTextBox.Text.Insert(insertPosition, Environment.NewLine + pattern);

                            // �L�����b�g�i�J�[�\���j��V�����s�̖����Ɉړ�
                            EditorTextBox.SelectionStart = insertPosition + Environment.NewLine.Length + pattern.Length;
                            break;
                        }
                    }
                }
            }
        }


        #endregion


        #region �⏕���\�b�h

        private void LoadFile(string path)
        {
            _originalText = File.ReadAllText(_savedPath); // �J�����Ƃ��̓��e��ۑ�
            _lastSavedMdFile.Save(path, _originalText);
            EditorTextBox.Text = _originalText;
            MessageBox.Show("�t�@�C����ǂݍ��݂܂����B", "�ǂݍ��݊���", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveFile(string path)
        {
            string markdownText = EditorTextBox.Text;
            File.WriteAllText(path, markdownText);
            _lastSavedMdFile.Save(path, markdownText);
            MessageBox.Show("�t�@�C�����ۑ�����܂����B", "�ۑ�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveInNewFile()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Markdown Files (*.md)|*.md";
                saveFileDialog.DefaultExt = "md";
                saveFileDialog.Title = "���O��t���ĕۑ�";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveFile(saveFileDialog.FileName);
                }
            }
        }

        #endregion
    }
}
