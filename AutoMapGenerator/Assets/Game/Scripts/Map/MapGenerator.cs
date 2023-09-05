#if UNITY_EDITOR
// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using InGame.ForMap.ForTheme;
using InGame.ForMap.ForItem;
using InGame.ForMap.ForColorFlag;

namespace InGame.ForMap
{
    [System.Serializable]
    public class ThemeInfo 
    {
        public EThemeType      ThemeType  = EThemeType.Unknown;
        public List<ItemInfo>  ItemGroup  = new List<ItemInfo>(); 
        public Floor           BasicFloor = null;
        public Floor           EndFloor   = null;
        public List<FlagInfo>  FlagGroup  = new List<FlagInfo>();
    }

    [System.Serializable]
    public class ItemInfo
    {
        public ESizeType  SizeType   = ESizeType.Unknown;
        public EColorType ColorType  = EColorType.Unknown;
        public Item       TargetItem = null;
    }

    [System.Serializable]
    public class FlagInfo
    {
        public EFlagType  FlagType   = EFlagType.Unknown;
        public EColorType ColorType  = EColorType.Unknown;
        public ColorFlag  TargetFlag = null;
    }

    public class MapGenerator : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("- 맵 옵션")]
        [SerializeField] private string          _mapTitle      = null;
        
        [Header("- 테마 관련 정보")]
        [SerializeField] private EThemeType      _themeType     = EThemeType.Unknown;
        [SerializeField] private List<ThemeInfo> _themeInfoList = new List<ThemeInfo>();

        [Header("- 스캔 구조")]
        [SerializeField] private ScanMap         _scanMap       = null;

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

            // Floor 구조 생성
            _ScanFloor();

            // Color Flag 구조 생성
            _ScanColorFlag();

            // Item 구조 생성
            _ScanItem();
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
            var   scanFloorList   = _scanMap.FloorList;
            var   scanEndFloor    = _scanMap.EndFloor;
            Floor basicFloorModel = null;
            Floor endFloorModel   = null;

            for (int i = 0; i < _themeInfoList.Count; i++)
            {
                var themeInfo = _themeInfoList[i];
                if (themeInfo.ThemeType == _themeType)
                {
                    basicFloorModel = themeInfo.BasicFloor;
                    endFloorModel   = themeInfo.EndFloor;
                    break;
                }
            }

            if (basicFloorModel == null || endFloorModel == null)
            {
                Debug.LogError($"[MapGenerator._ScanFloor] 해당 테마의 바닥 오브젝트가 존재하지 않습니다.");
                return;
            }

            for (int i = 0; i < scanFloorList.Count; i++)
            {
                var scanFloor  = scanFloorList[i];
                var basicFloor = Instantiate(basicFloorModel, _floorParents);

                basicFloor.transform.position = scanFloor.transform.position;
            }

            var endFloor = Instantiate(endFloorModel, _endFloorParents);
            endFloor.transform.position = scanEndFloor.transform.position;
        }

        private void _ScanColorFlag()
        {
            var scanColorFlagList = _scanMap.FlagList;
            var colorFlagInfoList = new List<FlagInfo>();

            for (int i = 0; i < _themeInfoList.Count; i++)
            {
                var themeInfo = _themeInfoList[i];

                if (themeInfo.ThemeType == _themeType)
                {
                    colorFlagInfoList = themeInfo.FlagGroup;
                    break;
                }
            }

            if (colorFlagInfoList == null)
            {
                Debug.LogError($"[MapGenerator._ScanColorFlag] 해당 테마의 깃발 오브젝트가 존재하지 않습니다.");
                return;
            }

            ColorFlag resultFlag = null;

            for (int i = 0; i < scanColorFlagList.Count; i++)
            {
                var colorFlag = scanColorFlagList[i];

                for (int j = 0; j < colorFlagInfoList.Count; j++)
                {
                    var scanColorFlag = colorFlagInfoList[j];
                    if (colorFlag.ColorType == scanColorFlag.ColorType && colorFlag.FlagType == scanColorFlag.FlagType)
                    {
                        resultFlag = scanColorFlag.TargetFlag;
                        break;
                    }
                }

                if (resultFlag == null)
                {
                    Debug.LogError($"[MapGenerator._ScanColorFlag] 해당 색과 타입의 깃발 오브젝트가 존재하지 않습니다.");
                    return;
                }

                var newFlag = Instantiate(resultFlag, _colorFlagParents);
                newFlag.transform.position = colorFlag.transform.position;
            }
        }

        private void _ScanItem()
        {
            var scanItemList = _scanMap.ItemList;
            var itemInfoList = new List<ItemInfo>();

            for (int i = 0; i < _themeInfoList.Count; i++)
            {
                var themeInfo = _themeInfoList[i];

                if (themeInfo.ThemeType == _themeType)
                {
                    itemInfoList = themeInfo.ItemGroup;
                    break;
                }
            }

            if (itemInfoList == null)
            {
                Debug.LogError($"[MapGenerator._ScanItem] 해당 테마의 아이템 오브젝트가 존재하지 않습니다.");
                return;
            }

            Item resultItem = null;

            for (int i = 0; i < scanItemList.Count; i++)
            {
                var scanItem = scanItemList[i];

                for (int j = 0; j < itemInfoList.Count; j++) 
                { 
                    var itemInfo = itemInfoList[j];
                    if (scanItem.ColorType == itemInfo.ColorType && scanItem.SizeType == itemInfo.SizeType)
                    {
                        resultItem = itemInfo.TargetItem;
                        break;
                    }
                }

                if (resultItem == null)
                {
                    Debug.LogError($"[MapGenerator._ScanItem] 해당 색과 타입의 아이템 오브젝트가 존재하지 않습니다.");
                    return;
                }

                var newItem = Instantiate(resultItem, _itemParents);
                newItem.transform.position = scanItem.transform.position;
            }
        }
    }
}
# endif