using System;
using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    public class Player : IPlayer
    {
        [SerializeField] private List<Artefact> _inventory = new List<Artefact>();
        [SerializeField] private int _shovelsCount;

        public int ShovelsCount => _shovelsCount;

        public event Action OnNotEnoughShovel;
        public event Action<int> OnSuccesfullDig;

        public Player(int startShovelsCount)
        {
            _shovelsCount = startShovelsCount;
        }

        public void Dig()
        {
            _shovelsCount--;
            OnSuccesfullDig?.Invoke(ShovelsCount);
        }

        public bool CheckCanDig()
        {
            if (ShovelsCount < 1)
            {
                OnNotEnoughShovel?.Invoke();
                return false;
            }
            return true;
        }
    }
}