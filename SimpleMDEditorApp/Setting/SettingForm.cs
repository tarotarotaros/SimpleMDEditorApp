using System;
using System.IO;
using System.Windows.Forms;

namespace SimpleMDEditorApp.Setting
{
    public partial class SettingForm : Form
    {
        private JsonSettingFile _jsonSettingFile;
        private readonly Form _owner;

        public SettingForm(Form owner, JsonSettingFile jsonSettingFile)
        {
            InitializeComponent();


            _jsonSettingFile = jsonSettingFile;
            _owner = owner;


            this.EnableAICheckBox.Checked = bool.Parse(_jsonSettingFile.Get(JsonSettingFile.ENABLE_API_SYMBOL));
            this.APIKeyTextBox.Text = _jsonSettingFile.Get(JsonSettingFile.API_KEY_SYMBOL);
            this.SaveImageFolderPathTextBox.Text = _jsonSettingFile.Get(JsonSettingFile.IMAGE_FOLDER_PATH_SYMBOL);
        }

        public void ShowWindow()
        {
            this.ShowDialog(_owner);
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            _jsonSettingFile.Set(JsonSettingFile.ENABLE_API_SYMBOL, this.EnableAICheckBox.Checked.ToString());
            _jsonSettingFile.Set(JsonSettingFile.API_KEY_SYMBOL, this.APIKeyTextBox.Text.ToString());
            _jsonSettingFile.Set(JsonSettingFile.IMAGE_FOLDER_PATH_SYMBOL, this.SaveImageFolderPathTextBox.Text.ToString());

            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveImageFolderPath_OpenFolderDialogButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "フォルダを選択してください";
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
                folderBrowserDialog.ShowNewFolderButton = true;

                DialogResult result = folderBrowserDialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    this.SaveImageFolderPathTextBox.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        /// <summary>
        /// フォルダ参照ダイアログを呼び出してパスを取得する
        /// </summary>
        /// <param name="select_path">初期パス(in)/選択パス(out)</param>
        /// <returns>true/false</returns>
        private bool GetDirNameFromOpenFileDialog(ref string select_path)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Title = "フォルダを選択してください。";
                //dlg.
                dlg.FileName = "";
                dlg.Filter = "Folder|.";
                dlg.CheckFileExists = false;

                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    //開く以外を選択された場合はfalseを返す。
                    return false;
                }

                select_path = System.IO.Path.GetDirectoryName(dlg.FileName);

            }

            return true;
        }

        private void EnableAICheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (EnableAICheckBox.Checked)
            {
                this.APIKeyTextBox.Enabled = true;
            }
            else
            {
                this.APIKeyTextBox.Enabled = false;
                this.APIKeyTextBox.Text = string.Empty;
            }
        }
    }
}
