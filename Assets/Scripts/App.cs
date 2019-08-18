using UnityEngine;
using Views;
using Models;
using Controllers;
using System.Collections;
using Utils;

namespace CrazyPandaTest
{
    public class App : MonoBehaviour
    {
        [SerializeField] private GameView _gameView;
        private GameController _gameController;
        private Game _gameData;

        private void Awake()
        {
            string saveData = PlayerPrefs.GetString(Saver.SAVE_STRING);
            if (PlayerPrefs.GetInt(Saver.LOAD_FLAG) != 0 && saveData != "")
                _gameData = Saver.Load();
            else
                _gameData = new Game(100, 3, 50);
            StartCoroutine(WaitPoolInit());
        }

        IEnumerator WaitPoolInit()
        {
            while (!PoolManager.Initialized)
                yield return null;
            StartGame(_gameData);
        }

        private void StartGame(Game game)
        {
            _gameController = new GameController(game);
            _gameView.SetUp(_gameController);
            _gameView.Init();
            _gameView.StartRender();
        }

        private void OnDestroy()
        {
            Saver.Save(_gameData);
        }
    }
}
