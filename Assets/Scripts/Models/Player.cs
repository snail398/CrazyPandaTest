﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class Player : IPlayer
    {
        [SerializeField] private List<Artefact> _inventory = new List<Artefact>();
        [SerializeField] private int _shovelsCount;

        public int ShovelsCount => _shovelsCount;

        public event Action OnNotEnoughShovel;
        public event Action<int> OnSuccesfullDig;
        public event Action<int> OnTakeNewArtefact;

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

        public void StartRender()
        {
            OnSuccesfullDig?.Invoke(ShovelsCount);
            OnTakeNewArtefact?.Invoke(CountScoreFromInventory());
        }

        public void TakeArtefact(Artefact artefact)
        {
            _inventory.Add(artefact);
            OnTakeNewArtefact?.Invoke(CountScoreFromInventory());
        }

        private int CountScoreFromInventory()
        {
            int score = 0;
            foreach (var artefact in _inventory)
            {
                score += artefact.Cost;
            }
            return score;
        }
    }
}