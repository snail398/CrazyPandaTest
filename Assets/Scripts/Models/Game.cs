using UnityEngine;
using System;
namespace Models
{
    [Serializable]
    public class Game
    {
        [SerializeField] private Map _map;
        [SerializeField] private Player _player;

        public Game(int cellCount, int cellDeep, int startShovelCount)
        {
            _map = new Map(cellCount, cellDeep);
            _player = new Player(startShovelCount);
        }

        public Map Map => _map;
        public Player Player  => _player; 
    }
}
