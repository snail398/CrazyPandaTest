using UnityEngine;

namespace Utils
{
    [AddComponentMenu("Pool/PoolObject")]
    public class PoolObject : MonoBehaviour
    {
        private Transform _poolParent;
        private Transform _canvas;
        private Transform _transform;

        public Transform Canvas  => _canvas; 
        public Transform PoolParent  => _poolParent; 
        private void Awake()
        {
            _transform = transform;
        }

        public void Initialize(Transform canvas, Transform parent)
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