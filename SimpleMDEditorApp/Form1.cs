using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Windows.Forms;

namespace SimpleMDEditorApp
{
    public partial class EditorForm : Form
    {
        public EditorForm()
        {
            InitializeComponent();
            InitializeAsync();
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
    }
}
