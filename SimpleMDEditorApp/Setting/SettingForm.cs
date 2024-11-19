using System;
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
        }

        public void ShowWindow()
        {
            this.ShowDialog(_owner);
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            _jsonSettingFile.Set(JsonSettingFile.ENABLE_API_SYMBOL, this.EnableAICheckBox.Checked.ToString());
            _jsonSettingFile.Set(JsonSettingFile.API_KEY_SYMBOL, this.APIKeyTextBox.Text.ToString());

            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
