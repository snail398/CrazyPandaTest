using UnityEngine;

namespace Utils
{
    public class HUDTransformManager : MonoBehaviour
    {
        [SerializeField] private RectTransform _canvas;
        [SerializeField] private RectTransform _inventoryPanel;

        private static HUDTransformManager _instance;

        public static HUDTransformManager Instance { get => _instance; }
        public RectTransform InventoryPanel => _inventoryPanel;
        public RectTransform Canvas  => _canvas;

        void Awake()
        {
            _instance = this;
        }
    }
}
