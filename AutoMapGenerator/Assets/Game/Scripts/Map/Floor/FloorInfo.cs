#if UNITY_EDITOR
// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using InGame.ForMap.ForTheme;

namespace InGame.ForMap
{
    [System.Serializable]
    public class FloorInfo
    {
        public EFloorType Type        = EFloorType.Unknown;
        public Floor      TargetFloor = null;
    }
}
#endif