#if UNITY_EDITOR
// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using InGame.ForMap.ForTheme;
using InGame.ForMap.ForItem;

namespace InGame.ForMap
{
    [System.Serializable]
    public class ThemeInfo 
    {
        public EThemeType     ThemeType  = EThemeType.Unknown;
        public Floor          BasicFloor = null;
        public List<ItemInfo> ItemGroup  = new List<ItemInfo>(); 
    }

    [System.Serializable]
    public class ItemInfo
    {
        public ESizeType  SizeType   = ESizeType.Unknown;
        public EColorType ColorType  = EColorType.Unknown;
        public Item       TargetItem = null;
    }

    public class MapGenerator : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("- 맵 옵션")]
        [SerializeField] private string     _mapTitle  = null;
        
        [Header("- 테마 관련 정보")]
        [SerializeField] private EThemeType      _themeType     = EThemeType.Unknown;
        [SerializeField] private List<ThemeInfo> _themeDataList = new List<ThemeInfo>();

        [Header("- 스캔 구조")]
        [SerializeField] private MapOrigin  _mapOrigin = null;

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
        // ----- Public
        [ContextMenu("Created Map")]
        public void CreatedMap()
        {
            // Map 구조 생성
            _CreatedStructure();

            // Map
        }

        // ----- Private
        private void _CreatedStructure()
        {
            var mapBase       = new GameObject();
            var floorBase     = new GameObject();
            var endFloorBase  = new GameObject();
            var gimmickBase   = new GameObject();
            var colorFlagBase = new GameObject();
            var itemBase      = new GameObject();
            
            mapBase.name       = $"{_mapTitle}_{_themeType}";
            floorBase.name     = PARENTS_FLOOR;
            endFloorBase.name  = PARENTS_ENDFLLOR;
            gimmickBase.name   = PARENTS_GIMMICK;
            colorFlagBase.name = PARENTS_COLORFLAGS;
            itemBase.name      = PARENTS_ITEMS;

            _mapParents       = mapBase.transform;
            _floorParents     = floorBase.transform;
            _endFloorParents  = endFloorBase.transform;
            _gimmickParents   = gimmickBase.transform;
            _colorFlagParents = colorFlagBase.transform;
            _itemParents      = itemBase.transform;
            
            mapBase.      transform.SetParent(transform);
            floorBase.    transform.SetParent(_mapParents);
            endFloorBase. transform.SetParent(_mapParents);
            gimmickBase.  transform.SetParent(_mapParents);
            colorFlagBase.transform.SetParent(_gimmickParents);
            itemBase.     transform.SetParent(_gimmickParents);
        }

        private void _ScanFloor()
        {
            var floorList = _mapOrigin.FloorList;

            for (int i = 0; i < floorList.Count; i++)
            {
                var floor = floorList[i];

            }
        }

        private void _SearchItem()
        {

        }
    }
}
# endif