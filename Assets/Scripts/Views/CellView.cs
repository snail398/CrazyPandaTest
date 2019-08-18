using UnityEngine;
using System;
using Controllers;
using Models;
using UnityEngine.UI;
using Utils;

namespace Views
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private Text _cellDeepText;
        private CellController _cellController;
        private ICell _cellObservable;
        private RectTransform _rectTransform;
        private ArtefactView _artefact;

        public RectTransform RectTransform { get => _rectTransform; set => _rectTransform = value; }

        private void Awake()
        {
            RectTransform = GetComponent<RectTransform>();
        }

        public void SetUp(CellController cellController, ICell cell)
        {
            _cellController = cellController;
            _cellObservable = cell;
            _cellObservable.OnCellChanged += Draw;
            _cellObservable.OnArtefactExplore += ExploreArtefact;
            _cellObservable.OnArtefactTaked += TakeArtefact;
            StartRender();
        }

        private void StartRender()
        {
            _cellController.StartRender();
        }

        public void OnClicked()
        {
            _cellController.Dig();
        }

        private void Draw(int deep)
        {
            _cellDeepText.text = deep.ToString();
        }

        private void ExploreArtefact()
        {
            _artefact = PoolManager.GetObject("ArtefactView").GetComponent<ArtefactView>();
            if (_artefact != null)
            {
                _artefact.SetUp(_cellController);
                _artefact.Explore(RectTransform);
            }
        }

        private void TakeArtefact()
        {
            if (_artefact != null)
            {
                _artefact.GetComponent<PoolObject>().ReturnToPool();
                _artefact = null;
            }
        }

        private void OnDestroy()
        {
            if (_cellObservable != null)
            {
                _cellObservable.OnCellChanged -= Draw;
                _cellObservable.OnArtefactExplore -= ExploreArtefact;
                _cellObservable.OnArtefactTaked -= TakeArtefact;
            }
        }
    }
}
