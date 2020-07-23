using UnityEngine;

namespace Match3.Core.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Game Settings")]
    public class GameSettings : ScriptableObject
    {
        public int Cols = 5;
        public int Rows = 5;

        public JewelPrefab[] jewelObjects;
    }
}