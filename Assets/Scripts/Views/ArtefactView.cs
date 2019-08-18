using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using Controllers;
using Models;

namespace Views
{
    public class ArtefactView : MonoBehaviour
    {
        private RectTransform _rectTransform;
        private CellController _cellController;
        private ICell _cellObservable;
                
        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public void SetUp(CellController cellController)
        {
            _cellController = cellController;
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
