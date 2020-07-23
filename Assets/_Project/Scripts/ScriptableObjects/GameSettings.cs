using Match3.Core;
using UnityEngine;

namespace Match3.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Game Settings")]
    public class GameSettings : ScriptableObject
    {
        public int Cols = 5;
        public int Rows = 5;

        public JewelObject[] jewelObjects;
    }
}