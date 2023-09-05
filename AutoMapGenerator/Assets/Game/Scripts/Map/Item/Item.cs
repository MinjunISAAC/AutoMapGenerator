// ----- Unity
using UnityEngine;

// ----- User Defined
using InGame.ForMap.ForTheme;

namespace InGame.ForMap.ForItem
{
    [System.Serializable]
    public class Item : MonoBehaviour
    {
        public ESizeType  SizeType  = ESizeType.Unknown;
        public EColorType ColorType = EColorType.Unknown;
    }
}