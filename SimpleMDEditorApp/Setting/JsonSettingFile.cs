using SimpleMDEditorApp.FileIO;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SimpleMDEditorApp.Setting
{
    public class JsonSettingFile
    {
        public const string ENABLE_API_SYMBOL = "EnableApi";
        public const string API_KEY_SYMBOL = "ApiKey";
        public const string IS_IMAGE_DROP_SYMBOL = "IsImageDrop";
        public const string IMAGE_FOLDER_PATH_SYMBOL = "ImageFolderPath";


        private readonly string _jsonFilePath;
        private Dictionary<string, string> _settings;
        private const string SETTING_FILE_NAME = "setting.json";

        public JsonSettingFile()
        {
            // jsonファイルのパス
            _jsonFilePath = Path.Combine(AppPath.AppFolder, SETTING_FILE_NAME);

            // ファイルが存在すれば読み込む
            if (File.Exists(_jsonFilePath))
            {
                Load();
            }
            else
            {
                // ファイルがなければ初期化して保存
                _settings = new Dictionary<string, string>
            {
                { ENABLE_API_SYMBOL, "false" },
                { API_KEY_SYMBOL, "" },
                { IMAGE_FOLDER_PATH_SYMBOL, AppPath.ImagesFolder }
            };
                Save();
            }
        }
        // 設定値を取得
        public string Get(string key, string defaultValue = "")
        {
            return _settings.ContainsKey(key) ? _settings[key] : defaultValue;
        }

        // 設定値を更新または追加
        public void Set(string key, string value)
        {
            _settings[key] = value;
            Save();
            Load();
        }

        // JSONファイルを読み込む
        public void Load()
        {
            var json = File.ReadAllText(_jsonFilePath);
            _settings = JsonSerializer.Deserialize<Dictionary<string, string>>(json)
                        ?? new Dictionary<string, string>();
        }


        // JSONファイルに保存
        private void Save()
        {
            var json = JsonSerializer.Serialize(_settings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_jsonFilePath, json);
        }
    }
}
