#if UNITY_EDITOR
// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using InGame.ForMap.ForTheme;

namespace InGame.ForMap.ForItem
{
    public class Item_Origin : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("Theme Select")]
        [SerializeField] private EThemeType      _themeType = EThemeType.Unknown;

        [Space] [Header("Item Options")]
        [SerializeField] private Item.ESizeType  _sizeType  = Item.ESizeType.Unknown;
        [SerializeField] private Item.EColorType _colorType = Item.EColorType.Unknown;
    }
}
#endif