using System;
using System.IO;

namespace SimpleMDEditorApp.FileIO
{
    public static class AppPath
    {

        public static string AppName
        {
            get
            {
                return "SimpleMDEditor";
            }
        }

        public static string ImageUrl
        {
            get
            {
                return "MyImageFiles";
            }
        }

        public static string AppFolder
        {
            get
            {
                var targetFolder = Path.Combine(RoamingFolder, AppName);
                return CreateDirectoryIfNotExists(targetFolder);
            }
        }

        public static string ImagesFolder
        {
            get
            {
                var targetFolder = Path.Combine(AppFolder, "Images");
                return CreateDirectoryIfNotExists(targetFolder);
            }
        }


        public static string EditorFolder
        {
            get
            {
                var targetFolder = Path.Combine(AppFolder, "Editor");
                return CreateDirectoryIfNotExists(targetFolder);
            }
        }

        public static string EditorTempFile
        {
            get
            {
                string filePath = Path.Combine(AppPath.EditorFolder, "edittemp.html");
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, string.Empty);
                }
                return filePath;
            }
        }

        public static string RoamingFolder
        {
            get { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); }
        }

        private static string CreateDirectoryIfNotExists(string targetFolder)
        {
            if (!Directory.Exists(targetFolder))
            {
                Directory.CreateDirectory(targetFolder);
            }

            return targetFolder;
        }
    }
}
