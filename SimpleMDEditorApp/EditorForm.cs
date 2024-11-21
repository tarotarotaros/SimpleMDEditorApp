using Markdig;
using Microsoft.Web.WebView2.Core;
using SimpleMDEditorApp.AI;
using SimpleMDEditorApp.FileIO;
using SimpleMDEditorApp.Setting;
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
        private readonly JsonSettingFile _jsonSettingFile;
        private bool _isEnableAI;

        public EditorForm()
        {
            InitializeComponent();
            
            File.Delete(AppPath.EditorTempFile);
            this.MarkDownWebView.Source = new Uri(AppPath.EditorTempFile);
            
            _jsonSettingFile = new JsonSettingFile();
            _isEnableAI = bool.Parse(_jsonSettingFile.Get(JsonSettingFile.ENABLE_API_SYMBOL));
            _textUtility = new TextUtility();
            _lastSavedMdFile = new MdFile();
            _gptComplement = new GPTComplement(_jsonSettingFile.Get(JsonSettingFile.API_KEY_SYMBOL));
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

            this.EditorTextBox.MouseWheel += EditorTextBox_MouseWheel;
            this.EditorTextBox.DragEnter += EditorTextBox_DragEnter;
            this.EditorTextBox.DragDrop += EditorTextBox_DragDrop;
        }

        #region �C�x���g

        /// <summary>
        /// �e�L�X�g�����͂��ꂽ��ꎞ�ۑ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditorTextBox_TextChanged(object sender, EventArgs e)
        {
            // EditorTextBox�̃e�L�X�g���擾���AHTML�ɕϊ�
            string markdownText = EditorTextBox.Text;
            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            string htmlContent = Markdown.ToHtml(markdownText, pipeline);
            File.WriteAllText(AppPath.EditorTempFile, htmlContent);


            int lineCount = EditorTextBox.Lines.Length;
            RowCountTextBox.Text = string.Empty;
            for (int i = 1; i <= lineCount; i++)
            {
                RowCountTextBox.AppendText(i.ToString() + Environment.NewLine);
            }

            MarkDownWebView.CoreWebView2.SetVirtualHostNameToFolderMapping(AppPath.ImageUrl, _jsonSettingFile.Get(JsonSettingFile.IMAGE_FOLDER_PATH_SYMBOL), CoreWebView2HostResourceAccessKind.Allow);

            this.MarkDownWebView.CoreWebView2.Navigate(AppPath.EditorTempFile);
        }

        /// <summary>
        /// �G�f�B�^�[�̃h���b�O�A���h�h���b�v�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditorTextBox_DragEnter(object sender, DragEventArgs e)
        {
            // �h���b�O���ꂽ�f�[�^���t�@�C���Ȃ�R�s�[���������
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// �G�f�B�^�[�̃h���b�O�A���h�h���b�v�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditorTextBox_DragDrop(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;

            // �h���b�O���ꂽ�t�@�C���̃p�X���擾
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                // �摜�t�@�C�����m�F
                foreach (string file in files)
                {
                    if (_textUtility.IsImageFileName(file))
                    {
                        File.Copy(file, Path.Combine(_jsonSettingFile.Get(JsonSettingFile.IMAGE_FOLDER_PATH_SYMBOL), Path.GetFileName(file)), true);
                        EditorTextBox.AppendText($"![{Path.GetFileName(file)}]({Path.Combine($"http://{AppPath.ImageUrl}/", Path.GetFileName(file))})\n");
                    }
                }
            }
        }

        /// <summary>
        /// �G�f�B�^�[�̃L�[���̓C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditorTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (_isEnableAI && _proposalStatus.Type == ProposalStatusType.Proposal)
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

            if (e.Control && e.KeyCode == Keys.Oemplus)
            {
                this.EditorTextBox.Font = new Font(this.EditorTextBox.Font.FontFamily, this.EditorTextBox.Font.Size + 2);
                this.RowCountTextBox.Font = new Font(this.RowCountTextBox.Font.FontFamily, this.RowCountTextBox.Font.Size + 2);
                e.Handled = true;
            }


            if (e.Control && e.KeyCode == Keys.OemMinus)
            {
                this.EditorTextBox.Font = new Font(this.EditorTextBox.Font.FontFamily, this.EditorTextBox.Font.Size - 2);
                this.RowCountTextBox.Font = new Font(this.RowCountTextBox.Font.FontFamily, this.RowCountTextBox.Font.Size - 2);
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

        private void EditorTextBox_MouseWheel(object sender, MouseEventArgs e)
        {
            //nop
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

        /// <summary>
        /// �ݒ�_�C�A���O��\��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void �ݒ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settingForm = new SettingForm(this, _jsonSettingFile);
            settingForm.ShowWindow();
            _jsonSettingFile.Load();
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
