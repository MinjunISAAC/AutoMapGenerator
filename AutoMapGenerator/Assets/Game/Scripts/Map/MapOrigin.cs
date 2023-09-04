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
    public class MapOrigin : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("- ½ºÄµ ¸ñ·Ï")]
        [SerializeField] private List<Floor> _floorList = new List<Floor>();

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public List<Floor> FloorList => _floorList;
    }
}
#endif