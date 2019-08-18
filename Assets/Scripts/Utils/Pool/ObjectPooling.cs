using System.Collections.Generic;
using UnityEngine;
using Views;

namespace Utils
{
    [AddComponentMenu("Pool/ObjectPooling")]
    public class ObjectPooling
    {

        #region Data
        private List<PoolObject> _objects;
        private Transform _objectsParent;
        private RectTransform _canvas;
        #endregion

        #region Interface
        public void Initialize(int count, PoolObject sample, Transform objects_parent, RectTransform canvas)
        {
            _objects = new List<PoolObject>();
            _objectsParent = objects_parent;
            _canvas = canvas;
            for (int i = 0; i < count; i++)
            {
                AddObject(sample, objects_parent, canvas);
            }
        }


        public PoolObject GetObject()
        {
            for (int i = 0; i < _objects.Count; i++)
            {
                if (_objects[i].gameObject.activeInHierarchy == false)
                {
                    return _objects[i];
                }
            }
            AddObject(_objects[0], _objectsParent, _canvas);
            return _objects[_objects.Count - 1];
        }
        #endregion

        #region Methods
        void AddObject(PoolObject sample, Transform objects_parent, RectTransform canvas)
        {
            GameObject temp;
            temp = GameObject.Instantiate(sample.gameObject);
            PoolObject obj = temp.GetComponent<PoolObject>();
            obj.Initialize(canvas,objects_parent);
            temp.name = sample.name;
            temp.transform.SetParent(objects_parent);
            _objects.Add(temp.GetComponent<PoolObject>());
            temp.SetActive(false);
        }
        #endregion

    }
}