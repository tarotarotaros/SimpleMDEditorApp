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
        private int _altPressCount = 0;       // Alt�L�[�̉�����
        private Timer _altPressTimer;        // Alt�L�[�����̊Ď��^�C�}�[
        private const int AltPressInterval = 500; // Alt�L�[2�񉟉��Ƃ݂Ȃ��Ԋu (ms)

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
                // �^�C�}�[�����΂�����J�E���g���Z�b�g
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
                this.MarkDownWebView.CoreWebView2.Navigate("./sample.html");

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
            _lastSavedMdFile = new MdFile();
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
                    LoadFile(openFileDialog.FileName); // �t�@�C���̓��e��ǂݍ���ŕ\��
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

            // Alt�L�[�̊Ď�
            if (e.KeyCode == Keys.Menu) // Alt�L�[��Keys.Menu�Ō��m
            {
                _altPressCount++;

                // �^�C�}�[���ăX�^�[�g
                _altPressTimer.Stop();
                _altPressTimer.Start();

                // Alt�L�[��2�񉟂��ꂽ�珈�������s
                if (_altPressCount == 2)
                {
                    HandleDoubleAltPress();
                    _altPressCount = 0; // �J�E���g���Z�b�g
                    _altPressTimer.Stop();
                }

                // Alt�L�[�̃f�t�H���g����𖳌������Ȃ��i�K�v�ɉ����ĕύX�j
                e.Handled = true;
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

        private async void HandleDoubleAltPress()
        {
            await _gptComplement.TalkAsyncForSingle(EditorTextBox.Text);
            FetchGPTResult();
        }


        #endregion


        #region �⏕���\�b�h

        /// <summary>
        /// �t�@�C����ǂݍ���
        /// </summary>
        /// <param name="path"></param>
        private void LoadFile(string path)
        {
            _originalText = File.ReadAllText(path); // �J�����Ƃ��̓��e��ۑ�
            _lastSavedMdFile.Save(path, _originalText);
            EditorTextBox.Text = _originalText;
            MessageBox.Show("�t�@�C����ǂݍ��݂܂����B", "�ǂݍ��݊���", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// �t�@�C����ۑ�
        /// </summary>
        /// <param name="path"></param>
        private void SaveFile(string path)
        {
            string markdownText = EditorTextBox.Text;
            File.WriteAllText(path, markdownText);
            _lastSavedMdFile.Save(path, markdownText);
            MessageBox.Show("�t�@�C�����ۑ�����܂����B", "�ۑ�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// �V�����t�@�C���Ƃ��ĕۑ�
        /// </summary>
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

        /// <summary>
        /// �e�L�X�g�̃J���[��ǉ����ĕύX����
        /// </summary>
        /// <param name="richTextBox"></param>
        /// <param name="addText"></param>
        private void ChageCharacterColor(RichTextBox richTextBox, string addText)
        {
            // RichTextBox�Ƀe�L�X�g��ݒ�
            richTextBox.Text += addText;

            int startIndex = richTextBox.Text.LastIndexOf(addText);

            if (startIndex != -1)
            {

                // �������I��
                richTextBox.Select(startIndex, addText.Length);

                // �I������������̐F��ύX
                richTextBox.SelectionColor = Color.Gray;

                // �I���������i�J�[�\���𖖔��ɖ߂��j
                richTextBox.Select(richTextBox.Text.Length, 0);

                _proposalStatus = new ProposalStatus(ProposalStatusType.Proposal, addText);
            }

        }

        /// <summary>
        // �w�肵��������𖖔������菜���֐�
        /// </summary>
        /// <param name="removeString"></param>
        private void RemoveStringFromEnd(string removeString)
        {
            // ���݂̃e�L�X�g
            string currentText = EditorTextBox.Text;

            // �������w�蕶����ƈ�v����ꍇ
            if (currentText.EndsWith(removeString))
            {
                // �w�蕶�������菜�����e�L�X�g��ݒ�
                EditorTextBox.Text = currentText.Substring(0, currentText.Length - removeString.Length);
            }
        }

        /// <summary>
        /// AI����̌��ʂ𔽉f�����܂��B
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
