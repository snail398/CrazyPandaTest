using UnityEngine;
using System;
using System.Collections.Generic;

namespace Models
{
    [Serializable]
    public class Map
    {
        [SerializeField] private List<Cell> _map = new List<Cell>();
        [SerializeField] private int _cellCount;

        public List<Cell> MapContents { get => _map; }
        
        public Map(int cellCount, int cellDeep)
        {
            _cellCount = cellCount;
            for (int i = 0; i < _cellCount; i++)
            {
                _map.Add(new Cell(cellDeep, 0));
            }
        }
    }
}
