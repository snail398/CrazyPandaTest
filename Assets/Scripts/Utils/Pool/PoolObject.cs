using UnityEngine;

namespace Utils
{
    [AddComponentMenu("Pool/PoolObject")]
    public class PoolObject : MonoBehaviour
    {
        private Transform _poolParent;
        private RectTransform _canvas;
        private Transform _transform;

        public RectTransform Canvas  => _canvas; 
        public Transform PoolParent  => _poolParent; 
        private void Awake()
        {
            _transform = transform;
        }

        public void Initialize(RectTransform canvas, Transform parent)
        {
            _canvas = canvas;
            _poolParent = parent;
        }
        public void ReturnToPool()
        {
            _transform.SetParent(_poolParent);
            gameObject.SetActive(false);
        }
    }
}