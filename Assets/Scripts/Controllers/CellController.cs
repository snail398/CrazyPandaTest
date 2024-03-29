﻿using Models;
using UnityEngine;

namespace Controllers
{
    public class CellController
    {
        private readonly Cell _cell;
        private readonly PlayerController _playerController;

        public CellController(Cell cell, PlayerController playerController)
        {
            _cell = cell;
            _playerController = playerController;
        }

        public Cell Cell => _cell;

        public void Dig()
        {
            if (_playerController == null) return;
            if (_playerController.CheckCanDig() && CheckCanDig())
            {
                _cell.Dig();
                _playerController.Dig();

                //Set Randomize
                if (Random.Range(0,100) < 30)
                    _cell.ExploreArtefact(new Artefact(Random.Range(50,200)));
            }
        }
        public bool CheckCanDig()
        {
            if (_cell == null) return false;
            return _cell.CheckCanDig();
        }

        public void TakeArtefact()
        {
            _playerController.TakeArtefact(_cell.Artefact);
            _cell.TakeArtefact();
        }

        public void StartRender()
        {
            _cell.StartRender();
        }
    }
}
