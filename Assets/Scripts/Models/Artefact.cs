using UnityEngine;

namespace Models
{
    public class Artefact
    {
        [SerializeField] private readonly int _cost;
        [SerializeField] private readonly int _size;

        public Artefact(int cost, int size = 1)
        {
            _cost = cost;
            _size = size;
        }

        public int Cost => _cost;
    }
}
