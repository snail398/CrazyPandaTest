using UnityEngine;
using Utils;
using Controllers;
using Models;
using UnityEngine.EventSystems;

namespace Views
{
    public class ArtefactView : MonoBehaviour, IPointerDownHandler, IDragHandler , IPointerUpHandler
    {
        private RectTransform _rectTransform;
        private CellController _cellController;
        private Vector3 _startArtefactPosition;
        private Vector2 _pointerOffset;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public void SetUp(CellController cellController)
        {
            _cellController = cellController;
        }

        public void OnPointerDown(PointerEventData data)
        {
            _startArtefactPosition = _rectTransform.localPosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_rectTransform, data.position, data.pressEventCamera, out _pointerOffset);
        }

        public void OnDrag(PointerEventData data)
        {
            if (_rectTransform == null)
                return;

            Vector2 pointerPostion = ClampToWindow(data);

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                HUDTransformManager.Instance.Canvas, pointerPostion, data.pressEventCamera, out Vector2 localPointerPosition
            ))
            {
                _rectTransform.localPosition = localPointerPosition - _pointerOffset;
            }
        }

        Vector2 ClampToWindow(PointerEventData data)
        {
            Vector2 rawPointerPosition = data.position;

            Vector3[] canvasCorners = new Vector3[4];
            HUDTransformManager.Instance.Canvas.GetWorldCorners(canvasCorners);

            float clampedX = Mathf.Clamp(rawPointerPosition.x, canvasCorners[0].x, canvasCorners[2].x);
            float clampedY = Mathf.Clamp(rawPointerPosition.y, canvasCorners[0].y, canvasCorners[2].y);

            Vector2 newPointerPosition = new Vector2(clampedX, clampedY);
            return newPointerPosition;
        }

        public void OnPointerUp(PointerEventData data)
        {
            Vector2 pointerPostion = ClampToWindow(data);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(HUDTransformManager.Instance.InventoryPanel, pointerPostion, data.pressEventCamera, out Vector2 localPointerPosition);
            if (HUDTransformManager.Instance.InventoryPanel == null || !HUDTransformManager.Instance.InventoryPanel.rect.Contains(localPointerPosition))
                _rectTransform.localPosition = _startArtefactPosition;
            else
                Take();
        }

        public void Explore(RectTransform cellTransform)
        {
            _rectTransform.sizeDelta = cellTransform.sizeDelta;
            _rectTransform.localPosition = cellTransform.localPosition; 
        }

        public void Take()
        {
            _cellController.TakeArtefact();
            GetComponent<PoolObject>().ReturnToPool();
        }

        
    }
}
