using Controllers;
using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Text _shovelsCountText;
        [SerializeField] private Text _errorText;
        [SerializeField] private Text _scoreText;
        private PlayerController _playerController;
        private IPlayer _playerObservable;

        public void SetUp(PlayerController playerController, IPlayer playerObservable)
        {
            _playerController = playerController;
            _playerObservable = playerObservable;
            _playerObservable.OnNotEnoughShovel += ShowError;
            _playerObservable.OnSuccesfullDig += DrawShovelsCount;
            _playerObservable.OnTakeNewArtefact += DrawScore;
            DrawShovelsCount(_playerController.Player.ShovelsCount);
        }

        private void DrawShovelsCount(int shovelCount)
        {
            if (_shovelsCountText != null)
                _shovelsCountText.text = shovelCount.ToString();
            else
                Debug.LogError("Set up HUD shovels count text");
        }

        private void DrawScore(int score)
        {
            if (_scoreText != null)
                _scoreText.text = score.ToString();
            else
                Debug.LogError("Set up HUD score text");
        }

        private void ShowError()
        {
            if (_errorText != null)
                _errorText.text = "Not enought shovels";
            else
                Debug.LogError("Set up HUD error text");
        }

        private void OnDestroy()
        {
            if (_playerObservable != null)
            {
                _playerObservable.OnNotEnoughShovel -= ShowError;
                _playerObservable.OnSuccesfullDig -= DrawShovelsCount;
                _playerObservable.OnTakeNewArtefact -= DrawScore;
            }
        }
    }
}
