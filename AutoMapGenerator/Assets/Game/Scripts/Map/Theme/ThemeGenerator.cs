# if UNITY_EDITOR
// ----- C#
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;
using UnityEditor;

namespace InGame.ForMap.ForTheme
{ 
    public sealed class ThemeGenerator : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("--- 테마 이름")]
        [SerializeField] string _themeName = "";

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        private const string FILE_PATH = "Assets/Game/Scripts/Map/Theme/EThemeType.cs";

        private const string SCRIPTS_START =
            "namespace InGame.ForMap.ForTheme\n" +
            "{\n" +
            "    public enum EThemeType\n" +
            "    {\n" +
            "        Unknown = 0,\n";

        private const string SCRIPTS_END =
            "    }\n" +
            "}";

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        [ContextMenu("Map/New Theme")]
        public void CreatedTheme()
        {
            if (Enum.TryParse(typeof(EThemeType), _themeName, out var result))
            {
                Debug.Log($"[ThemeGenerator.CreatedTheme] 해당 테마가 이미 존재합니다.");
                return;
            }

            // 테마 타입 생성하기
            var      fileContent = File.ReadAllText(FILE_PATH);
            string[] lines       = fileContent.Split('\n');

            fileContent = string.Join("\n", lines, 0, lines.Length - 2);
            fileContent =
            fileContent + "\n" +
            $"        {_themeName} = {lines.Length - 6},\n" +
            SCRIPTS_END;
            
            File.WriteAllText(FILE_PATH, fileContent);

            AssetDatabase.Refresh();
        }
    }
}
#endif