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
        [SerializeField] private  Text _shovelsCountText;
        [SerializeField] private  Text _errorText;
        private PlayerController _playerController;
        private IPlayer _playerObservable;

        public void SetUp(PlayerController playerController, IPlayer playerObservable)
        {
            _playerController = playerController;
            _playerObservable = playerObservable;
            _playerObservable.OnNotEnoughShovel += ShowError;
            _playerObservable.OnSuccesfullDig += DrawShovelsCount;
            DrawShovelsCount(_playerController.Player.ShovelsCount);
        }

        private void DrawShovelsCount(int shovelCount)
        {
            _shovelsCountText.text = shovelCount.ToString();
        }

        private void ShowError()
        {
            _errorText.text = "Not enought shovels";
        }

        private void OnDestroy()
        {
            _playerObservable.OnNotEnoughShovel -= ShowError;
            _playerObservable.OnSuccesfullDig -= DrawShovelsCount;
        }
    }
}
