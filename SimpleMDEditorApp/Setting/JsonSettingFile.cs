using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SimpleMDEditorApp.Setting
{
    public class JsonSettingFile
    {
        public const string ENABLE_API_SYMBOL = "EnableApi";
        public const string API_KEY_SYMBOL = "ApiKey";
        private readonly string _jsonFilePath;
        private Dictionary<string, string> _settings;
        private const string APP_NAME = "SimpleMDEditor";
        private const string SETTING_FILE_NAME = "setting.json";

        public JsonSettingFile()
        {
            // Roamingフォルダのパス
            string roamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appFolderPath = Path.Combine(roamingPath, APP_NAME);

            // アプリケーションフォルダを確認・作成
            if (!Directory.Exists(appFolderPath))
            {
                Directory.CreateDirectory(appFolderPath);
            }

            // jsonファイルのパス
            _jsonFilePath = Path.Combine(appFolderPath, SETTING_FILE_NAME);

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
                { API_KEY_SYMBOL, "" }
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
