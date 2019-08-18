using UnityEngine;
using System;

namespace Models
{
    [Serializable]
    public class Cell : ICell
    {
        [SerializeField] private int _maxDeep;
        [SerializeField] private int _currentDeep;
        [SerializeField] private Artefact _artefact;

        public int MaxDeep { get => _maxDeep; set => _maxDeep = value; }
        public int CurrentDeep { get => _currentDeep; set => _currentDeep = value; }
        public Artefact Artefact { get => _artefact; set => _artefact = value; }

        public event Action<int> OnCellChanged;
        public event Action OnArtefactExplore;
        public event Action OnArtefactTaked;

        public Cell(int maxDeep, int currentDeep)
        {
            if (maxDeep < 1)
                Debug.LogError("Deep cant be less, than 1(one)");
            _maxDeep = maxDeep;
            _currentDeep = currentDeep;
        }

        public void StartRender()
        {
            CheckArtefact();
            OnCellChanged?.Invoke(_currentDeep);
            if (_artefact != null)
                OnArtefactExplore?.Invoke();
        }

        private void CheckArtefact()
        {
            if (_artefact != null)
                if (_artefact.Cost == 0)
                    _artefact = null;
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

        public void ExploreArtefact(Artefact artefact)
        {
            if (_artefact == null)
            {
                _artefact = artefact;
                OnArtefactExplore?.Invoke();
            }
            else
                Debug.Log("Already have artefact in cell");
        }

        public void TakeArtefact()
        {
            if (_artefact != null)
            {
                _artefact = null;
                OnArtefactTaked?.Invoke();
            }
            else
                Debug.Log("Dont have artefact in cell");
        }
    }
}
