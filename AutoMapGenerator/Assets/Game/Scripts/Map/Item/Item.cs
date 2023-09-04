// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using InGame.ForMap.ForTheme;

namespace InGame.ForMap.ForItem
{
    public class Item : MonoBehaviour
    {
        // --------------------------------------------------
        // Item Enum Group
        // --------------------------------------------------
        public enum ESizeType
        {
            Unknown = 0,
            One_One = 1,
            Two_Two = 2,
        }

        public enum EColorType
        {
            Unknown = 0,
            Color_0 = 1,
            Color_1 = 2,
            Color_2 = 3,
        }

        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("Item Options")]
        [SerializeField] private EThemeType _themeType = EThemeType.Unknown;
        [SerializeField] private ESizeType  _sizeType  = ESizeType.Unknown;
        [SerializeField] private EColorType _colorType = EColorType.Unknown;
    }
}