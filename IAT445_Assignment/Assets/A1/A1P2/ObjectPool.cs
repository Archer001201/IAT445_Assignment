using System;
using System.Collections.Generic;
using UnityEngine;

namespace A1.A1P2
{
    public class ObjectPool : MonoBehaviour
    {
        public static ObjectPool Instance;
        public GameObject pipePrefab;
        public int pooledAmount;
        public bool allowGrow;

        private List<GameObject> _pooledObjects;

        private void Awake()
        {
           InitializeSingleton();
           InitializeObjectsList();
        }
        
        private void InitializeSingleton()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void InitializeObjectsList()
        {
            _pooledObjects = new List<GameObject>();
            
            for (var i = 0; i < pooledAmount; i++)
            {
                var obj = Instantiate(pipePrefab);
                obj.SetActive(false);
                _pooledObjects.Add(obj);
            }
        }

        public GameObject GetPooledObject()
        {
            for (var i = 0; i < pooledAmount; i++)
            {
                if (!_pooledObjects[i].activeInHierarchy) return _pooledObjects[i];
            }

            if (!allowGrow) return null;
            
            var obj = Instantiate(pipePrefab);
            obj.SetActive(false);
            _pooledObjects.Add(obj);
            return obj;
        }
    }
}
