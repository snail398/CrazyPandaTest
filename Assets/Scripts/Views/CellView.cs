using UnityEngine;
using System;
using Controllers;
using Models;
using UnityEngine.UI;

namespace Views
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private Text _cellDeepText;
        private CellController _cellController;
        private ICell _cellObservable;
        private RectTransform _rectTransform;

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
            Draw(0);
        }

        public void OnClicked()
        {
            _cellController.Dig();
        }

        private void Draw(int deep)
        {
            _cellDeepText.text = deep.ToString();
        }

        private void OnDestroy()
        {
            _cellObservable.OnCellChanged -= Draw;
        }
    }
}
