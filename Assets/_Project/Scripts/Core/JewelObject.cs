using Match3.Enums;
using UnityEngine;

namespace Match3.Core
{
    [System.Serializable]
    public struct JewelObject
    {
        public JewelType jewelType;
        public GameObject jewelPrefab;
    }
}