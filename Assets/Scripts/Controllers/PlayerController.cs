using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;

namespace Controllers
{
    public class PlayerController
    {
        private readonly Player _player;

        public Player Player => _player;

        public PlayerController(Player player)
        {
            _player = player;
        }

        public bool CheckCanDig()
        {
            if (_player == null) return false;
            return _player.CheckCanDig();
        }
        
        public void Dig()
        {
            if (_player == null) return; 
            _player.Dig();
        }
    }
}
