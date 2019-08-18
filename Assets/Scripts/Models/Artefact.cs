using UnityEngine;
using System;

namespace Models
{
    [Serializable]
    public class Artefact
    {
        [SerializeField] private int _cost;
        [SerializeField] private int _size;

        public Artefact(int cost, int size = 1)
        {
            _cost = cost;
            _size = size;
        }

        public int Cost => _cost;
    }
}
