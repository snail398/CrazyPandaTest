using UnityEngine;
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
        private ArtefactView _artefactView;

        public RectTransform RectTransform  => _rectTransform; 

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public void SetUp(CellController cellController, ICell cell)
        {
            _cellController = cellController;
            _cellObservable = cell;
            _cellObservable.OnCellChanged += Draw;
            _cellObservable.OnArtefactExplore += ExploreArtefact;
            _cellObservable.OnArtefactTaked += TakeArtefact;
        }

        public void StartRender()
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
            _artefactView = PoolManager.GetObject("ArtefactView").GetComponent<ArtefactView>();
            if (_artefactView != null)
            {
                _artefactView.SetUp(_cellController);
                _artefactView.Explore(_rectTransform);
            }
        }

        private void TakeArtefact()
        {
            if (_artefactView != null)
            {
                _artefactView.GetComponent<PoolObject>().ReturnToPool();
                _artefactView = null;
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
