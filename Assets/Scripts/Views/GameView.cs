using Controllers;
using System.Collections.Generic;
using UnityEngine;

namespace Views
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private  CellView _cellPrefab;
        [SerializeField] private  Transform _canvas;
        [SerializeField] private  PlayerView _playerView;
        private readonly List<CellView> _cellList = new List<CellView>();
        private IMapViewStrategy _mapView;
        private GameController _gameController;

        public void SetUp(GameController gameController)
        {
            _gameController = gameController;
            foreach (var cellController in _gameController.CellControllersList)
            {
                CellView tempCellView = Instantiate(_cellPrefab, _canvas) as CellView;
                tempCellView.SetUp(cellController, cellController.Cell);
                _cellList.Add(tempCellView);
            }
            _playerView.SetUp(_gameController.PlayerController, _gameController.PlayerController.Player);
        }

        public void Init()
        {
            _mapView = new SquareMapView();
            _mapView.DrawMap(_cellList);
        }
    }
}
