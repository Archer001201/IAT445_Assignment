using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace A1.A1P2
{
    public class PipeSpawner : MonoBehaviour
    {
        public float spawnInterval = 2.0f;
        public float offsetY = 15;
        public float startPosition = 50;
        
        private static PipeSpawner _spawner;
        private Coroutine _spawningCoroutine;

        private void Awake()
        {
            InitializeSingleton();
        }

        private void OnDisable()
        {
            if (_spawningCoroutine == null) return;
            StopCoroutine(_spawningCoroutine);
            _spawningCoroutine = null;
        }

        private void Start()
        {
            _spawningCoroutine ??= StartCoroutine(SpawnPipes());
        }

        private void InitializeSingleton()
        {
            if (!_spawner)
            {
                _spawner = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        private IEnumerator SpawnPipes()
        {
            while (true)
            {
                var pipe = ObjectPool.Instance.GetPooledObject();
                if (pipe)
                {
                    pipe.transform.position = new Vector3(startPosition, Random.Range(-offsetY, offsetY), 0);
                    pipe.SetActive(true);
                }
                yield return new WaitForSeconds(spawnInterval);
            }
            // ReSharper disable once IteratorNeverReturns
        }
    }
}
