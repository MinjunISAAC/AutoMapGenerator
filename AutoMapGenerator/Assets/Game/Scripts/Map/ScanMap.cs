#if UNITY_EDITOR
// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using InGame.ForMap.ForColorFlag;
using InGame.ForMap.ForItem;

namespace InGame.ForMap
{
    public class ScanMap : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("- �ٴ� ���")]
        [SerializeField] private List<Floor>            _floorList = new List<Floor>();
        [SerializeField] private Floor                  _endFloor  = null;

        [Header("- ���� ��� ���")]
        [SerializeField] private List<ColorFlag_Origin> _flagList  = new List<ColorFlag_Origin>();

        [Header("- ������ ���")]
        [SerializeField] private List<Item_Origin>      _itemList  = new List<Item_Origin>();

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public List<Floor>            FloorList => _floorList;
        public Floor                  EndFloor  => _endFloor;
        public List<ColorFlag_Origin> FlagList  => _flagList;
        public List<Item_Origin>      ItemList  => _itemList;
    }
}
#endif