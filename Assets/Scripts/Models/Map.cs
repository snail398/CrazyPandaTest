using UnityEngine;
using System;
using System.Collections.Generic;

namespace Models
{
    public class Map
    {
        [SerializeField] private readonly List<Cell> _map = new List<Cell>();
        [SerializeField] private readonly int _cellCount;

        public List<Cell> MapContents { get => _map; }

        public Map(int cellCount, int cellDeep)
        {
            _cellCount = cellCount;
            for (int i = 0; i < _cellCount; i++)
            {
                _map.Add(new Cell(cellDeep));
            }
        }
    }
}
