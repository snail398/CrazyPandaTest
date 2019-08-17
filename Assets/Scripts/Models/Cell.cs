using UnityEngine;
using System;

namespace Models
{
    public class Cell : ICell
    {
        [SerializeField] private int _maxDeep;
        [SerializeField] private int _currentDeep;

        public int MaxDeep { get => _maxDeep; set => _maxDeep = value; }
        public int CurrentDeep { get => _currentDeep; set => _currentDeep = value; }

        public event Action<int> OnCellChanged;
        
        public Cell(int maxDeep)
        {
            if (maxDeep < 1)
                Debug.LogError("Deep cant be less, than 1(one)");
            _maxDeep = maxDeep;
            _currentDeep = 0;
        }

        public void Dig()
        {
            _currentDeep++;
            OnCellChanged?.Invoke(_currentDeep);
        }

        public bool CheckCanDig()
        {
            return _currentDeep < _maxDeep;
        }
    }
}
