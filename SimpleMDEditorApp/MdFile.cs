using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMDEditorApp
{
    internal class MdFile
    {
        public string SavedFilePath => _savedFilePath;

        private string _savedFilePath;
        private string _mdFileText;

        public MdFile()
        {
            _savedFilePath = null;
            _mdFileText = null;
        }

        internal void Save(string filePath, string markdownText)
        {
            _savedFilePath = filePath;
            _mdFileText = markdownText;
        }

        public bool IsEmpty()
        {
            return _mdFileText == null;
        }
    }
}
