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
        [Header("Item Options")]
        [SerializeField] private ESizeType  _sizeType  = ESizeType.Unknown;
        [SerializeField] private EColorType _colorType = EColorType.Unknown;

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public ESizeType  SizeType  => _sizeType;
        public EColorType ColorType => _colorType;
    }
}
#endif