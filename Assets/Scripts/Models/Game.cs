using UnityEngine;
using System;
namespace Models
{
    public class Game
    {
        [SerializeField] private readonly Map _map;
        [SerializeField] private readonly Player _player;

        public Game(int cellCount, int cellDeep, int startShovelCount)
        {
            _map = new Map(cellCount, cellDeep);
            _player = new Player(startShovelCount);
        }

        public Map Map => _map;
        public Player Player  => _player; 
    }
}
