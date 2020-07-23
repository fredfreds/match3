using Match3.Core.Enums;
using UnityEngine;

namespace Match3.Core.Components 
{
    public class JewelComponent : MonoBehaviour
    {
        public void Init(int col, int row, GridManager grid, JewelType jewelType)
        {
            Col = col;
            Row = row;
            JewelType = jewelType;
            Grid = grid;
        }

        public int Col { get; private set; }
        public int Row { get; private set; }

        public JewelType JewelType { get; private set; }

        public GridManager Grid { get; private set; }
    }
}