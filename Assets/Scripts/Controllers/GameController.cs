using Models;
using System.Collections.Generic;

namespace Controllers
{
    public class GameController
    {
        private readonly Game _game;
        private readonly List<CellController> _cellControllersList = new List<CellController>();
        private readonly PlayerController _playerController;

        public List<CellController> CellControllersList => _cellControllersList;

        public PlayerController PlayerController => _playerController;

        public GameController(Game game)
        {
            _game = game;
            _playerController = new PlayerController(_game.Player);
            foreach (var cell in _game.Map.MapContents)
                _cellControllersList.Add(new CellController(cell, _playerController));
        }
    }
}
