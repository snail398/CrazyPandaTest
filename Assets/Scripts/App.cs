using UnityEngine;
using Views;
using Models;
using Controllers;
using System;

namespace CrazyPandaTest
{
    public class App : MonoBehaviour
    {
        [SerializeField] private GameView _gameView;
        private GameController _gameController;

        private void Awake()
        {
            StartGame(new Game(9,3,20));
        }

        private void StartGame(Game game)
        {
            _gameController = new GameController(game);
            _gameView.SetUp(_gameController);
            _gameView.Init();
        }
    }
}
