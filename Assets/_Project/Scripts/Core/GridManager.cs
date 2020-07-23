using Match3.Core.Components;
using Match3.Core.Enums;
using Match3.Core.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Core
{
    public class GridManager : MonoBehaviour
    {
        [SerializeField] private GameSettings gameSettings;

        // ассоциируем тип драгоценности с игровым объектом
        private Dictionary<JewelType, GameObject> jewelsDict
            = new Dictionary<JewelType, GameObject>();

        private JewelPrefab[] jewelObjects;

        private JewelComponent[,] pieces;

        private void Start()
        {
            InitJewelsDictionary();
            SetupGrid();
        }

        // т.к. в юнити нет возможности сериализации словарей
        private void InitJewelsDictionary()
        {
            jewelObjects = gameSettings.jewelObjects;

            for (int i = 0; i < jewelObjects.Length; i++)
            {
                if(!jewelsDict.ContainsKey(jewelObjects[i].jewelType))
                {
                    jewelsDict.Add(jewelObjects[i].jewelType, jewelObjects[i].jewelPrefab);
                }
            }
        }

        private void SetupGrid()
        {
            int cols = gameSettings.Cols;
            int rows = gameSettings.Rows;

            pieces = new JewelComponent[cols, rows];

            for (int c = 0; c < cols; c++)
            {
                for (int r = 0; r < rows; r++)
                {
                    GameObject piece = Instantiate(jewelsDict[JewelType.STANDART], GetGridOffset(c, r), Quaternion.identity);
                    piece.name = "Jewel (" + c + "/" + r + ")";
                    piece.transform.parent = transform;

                    pieces[c, r] = piece.GetComponent<JewelComponent>();
                    pieces[c, r].Init(c, r, this, JewelType.STANDART);
                }
            }
        }

        // позиция драгоценности в мировом пространстве
        Vector2 GetGridOffset(int colsOffset, int rowsOffset)
        {
            return new Vector2(transform.position.x - gameSettings.Cols / 2 + colsOffset,
                transform.position.y + gameSettings.Rows / 2 - rowsOffset);
        }
    }
}