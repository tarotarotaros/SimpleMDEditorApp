using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleMDEditorApp.Editor
{
    public partial class SearchForm : Form
    {
        private readonly EditorForm _ownerEditorForm;

        public SearchForm(EditorForm owner)
        {
            InitializeComponent();
            _ownerEditorForm = owner;
        }


        public void ShowWindow()
        {
            this.Show(_ownerEditorForm);
            _ownerEditorForm.MainMenuStrip.Enabled = false;
        }

        private void NextSearchButton_Click(object sender, EventArgs e)
        {
            _ownerEditorForm.Activate();
            _ownerEditorForm.Search(this.SearchTextBox.Text, this.UpperLowerCheckBox.Checked);
            if (this.CloseAfterSearchCheckBox.Checked)
            {
                CloseWindow();
            }
        }

        private void PreviousSearchButton_Click(object sender, EventArgs e)
        {
            _ownerEditorForm.Activate();
            _ownerEditorForm.SearchBackward(this.SearchTextBox.Text, this.UpperLowerCheckBox.Checked);
            if (this.CloseAfterSearchCheckBox.Checked)
            {
                CloseWindow();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            CloseWindow();
        }

        private void CloseWindow()
        {
            _ownerEditorForm.MainMenuStrip.Enabled = true;
            this.Close();
        }
    }
}
