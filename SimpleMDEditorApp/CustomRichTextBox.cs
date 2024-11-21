using System;
using System.Windows.Forms;

namespace SimpleMDEditorApp
{
    public partial class CustomRichTextBox : RichTextBox
    {
        private const int MK_CONTROL = 0x0008;
        private const int WM_MOUSEWHEEL = 0x020A;

        public CustomRichTextBox() {

            InitializeComponent();

        }

        /// <summary>
        /// ズームを無効化
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_MOUSEWHEEL:
                    // WParam を long にキャストして処理
                    long wParam = m.WParam.ToInt64();
                    if ((wParam & MK_CONTROL) == MK_CONTROL)
                    {
                        // WParam と Result を安全に操作
                        m.WParam = IntPtr.Zero;
                        m.Result = IntPtr.Zero;
                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }
    }
}
