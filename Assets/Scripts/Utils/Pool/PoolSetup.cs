using UnityEngine;

namespace Utils
{
    [AddComponentMenu("Pool/PoolSetup")]
    public class PoolSetup : MonoBehaviour
    {//обертка для управления статическим классом PoolManager

        #region Unity scene settings
        [SerializeField] private PoolManager.PoolPart[] _pools;
        [SerializeField] private RectTransform _canvas;
        #endregion

        #region Methods
        void OnValidate()
        {
            for (int i = 0; i < _pools.Length; i++)
            {
                _pools[i].name = _pools[i].prefab.name;
            }
        }

        void Awake()
        {
            Initialize();
        }

        void Initialize()
        {
            if (_canvas == null)
                Debug.LogError("Set canvas to Pool Setup");
            PoolManager.Initialize(_pools, _canvas);
        }
        #endregion
    }
}