using Match3.Enums;
using Match3.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Core
{
    public class GridManager : MonoBehaviour
    {
        [SerializeField] private GameSettings gameSettings;

        // ассоциируем тип драгоценности с игровым объектом
        private Dictionary<JewelType, GameObject> jewelsDict;
    }
}