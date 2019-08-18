using UnityEngine;

namespace Utils
{
    public static class PoolManager
    {
        private static PoolPart[] _pools;
        private static GameObject _objectsParent;
        private static bool _initialized;

        public static bool Initialized => _initialized;

        [System.Serializable]
        public struct PoolPart
        {
            public string name;
            public PoolObject prefab;
            public int count;
            public ObjectPooling ferula;
        }

        public static void Initialize(PoolPart[] newPools, RectTransform canvas)
        {
            _pools = newPools;
            _objectsParent = new GameObject();
            _objectsParent.name = "Pool";
            for (int i = 0; i < _pools.Length; i++)
            {
                if (_pools[i].prefab != null)
                {
                    _pools[i].ferula = new ObjectPooling();
                    _pools[i].ferula.Initialize(_pools[i].count, _pools[i].prefab, _objectsParent.transform, canvas);
                }
            }
            _initialized = true;
        }


        public static GameObject GetObject(string name)
        {
            GameObject result = null;
            if (_pools != null)
            {
                for (int i = 0; i < _pools.Length; i++)
                {
                    if (string.Compare(_pools[i].name, name) == 0)
                    {
                        result = _pools[i].ferula.GetObject().gameObject;
                        result.transform.SetParent(result.GetComponent<PoolObject>().Canvas);
                        result.SetActive(true);
                        return result;
                    }
                }
            }
            return result;
        }

    }
}