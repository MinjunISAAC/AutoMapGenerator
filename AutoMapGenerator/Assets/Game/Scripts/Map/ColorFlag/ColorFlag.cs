// ----- C#
using InGame.ForMap.ForItem;
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

namespace InGame.ForMap.ForColorFlag
{
    public class ColorFlag : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("- Ÿ�� ����")]
        [SerializeField] private EColorType _colorType = EColorType.Unknown;
        [SerializeField] private EFlagType  _flagType  = EFlagType.Unknown;

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public EColorType ColorType => _colorType;
        public EFlagType  FlagType  => _flagType;
    }
}