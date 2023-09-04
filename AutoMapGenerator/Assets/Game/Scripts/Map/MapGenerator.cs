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
    public class MapGenerator : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("- 테마 유형")]
        [SerializeField] private EThemeType _themeType = EThemeType.Unknown;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        // ----- Const
        private const string PARENTS_FLOOR      = "--- Floor";
        private const string PARENTS_ENDFLLOR   = "--- End Floor";
        private const string PARENTS_GIMMICK    = "--- Gimmicks";
        private const string PARENTS_COLORFLAGS = "--- Color Flags";
        private const string PARENTS_ITEMS      = "--- Items";

        // ----- Private
        private Transform _mapParents       = null;
        private Transform _floorParents     = null;
        private Transform _endFloorParents  = null; 
        private Transform _gimmickParents   = null;
        private Transform _colorFlagParents = null;
        private Transform _itemParents      = null;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void CreatedMap()
        {
            // Map 구조 생성
        }

    }
}
# endif