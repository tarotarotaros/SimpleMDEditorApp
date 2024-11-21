using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMDEditorApp
{
    public class TextUtility
    {


        public string AddTrailingAsterisk(string input)
        {
            return input.EndsWith(" *") ? input : input + " *";
        }

        public string RemoveTrailingAsterisk(string input)
        {
            return input.EndsWith(" *") ? input.Substring(0, input.Length - 2) : input;
        }

        public bool IsImageFileName(string file)
        {
            return file.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                                    file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                    file.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                                    file.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
                                    file.EndsWith(".gif", StringComparison.OrdinalIgnoreCase);
        }
    }


}
