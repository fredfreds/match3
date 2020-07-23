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
        private Dictionary<JewelType, GameObject> jewelsDict
            = new Dictionary<JewelType, GameObject>();

        private JewelPrefab[] jewelObjects;

        private GameObject[,] pieces;

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

            pieces = new GameObject[cols, rows];

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    pieces[i, j] = Instantiate(jewelsDict[JewelType.STANDART], GetGridOffset(i, j), Quaternion.identity);
                    Debug.Log(GetGridOffset(i, j));
                    pieces[i, j].name = "Jewel (" + i + "/" + j + ")";
                    pieces[i, j].transform.parent = transform;
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