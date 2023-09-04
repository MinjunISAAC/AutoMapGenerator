// ----- Unity
using UnityEngine;

// ----- User Defined
using InGame.ForMap.ForTheme;

namespace InGame.ForMap.ForItem
{
    [System.Serializable]
    public class Item : MonoBehaviour
    {
        public ESizeType  ThemeType = ESizeType.Unknown;
        public EColorType ColorType = EColorType.Unknown;
        public ItemInfo   Info      = null;
    }
}