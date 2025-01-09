using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dimasyechka
{
    public class CloudsGenerator : MonoBehaviour
    {
        [SerializeField]
        private CloudBehaviour[] _cloudPrefabs;

        [Header("Setting")]
        [SerializeField]
        private float _minCloudsSpawnPoint = 0f;

        [SerializeField]
        private float _maxCloudsSpawnPoint = 10f;

        [SerializeField]
        private float _spawnInterval = 2f;

        [SerializeField]
        private int _minSpawnAmount = 3;

        [SerializeField]
        private int _maxSpawnAmount = 9;


        private List<CloudBehaviour> _activeClouds = new List<CloudBehaviour>();


        private Coroutine _cloudsSpawnerCoroutine;


        private void Start()
        {
            StartSpawner();
        }

        private void OnDestroy()
        {
            StopSpawner();
        }


        private void FixedUpdate()
        {
            MoveClouds();
            DestroyClouds();
        }


        private void StartSpawner()
        {
            StopSpawner();

            _cloudsSpawnerCoroutine = StartCoroutine(CloudsGenerationProcess());
        }

        private void StopSpawner()
        {
            if (_cloudsSpawnerCoroutine != null)
            {
                StopCoroutine(_cloudsSpawnerCoroutine);
            }
        }


        private void MoveClouds()
        {
            foreach (CloudBehaviour cloudBehaviour in _activeClouds)
            {
                if (cloudBehaviour == null) continue;

                cloudBehaviour.Move();
            }
        }

        private void DestroyClouds()
        {
            for (int i = _activeClouds.Count - 1; i >= 0; i--)
            {
                if (_activeClouds[i] == null) continue;

                Vector3 cloudViewPosition = Camera.main.WorldToViewportPoint(_activeClouds[i].transform.position);

                if (cloudViewPosition.x <= 0)
                {
                    _activeClouds[i].MarkToDestroy();
                }
            }

            for (int i = _activeClouds.Count - 1; i >= 0; i--)
            {
                if (_activeClouds[i] == null)
                {
                    _activeClouds.RemoveAt(i);
                }
            }
        }


        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(new Vector3(-1000, _minCloudsSpawnPoint, 0), new Vector3(1000, _minCloudsSpawnPoint, 0));

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(new Vector3(-1000, _maxCloudsSpawnPoint, 0), new Vector3(1000, _maxCloudsSpawnPoint, 0));
        }


        private IEnumerator CloudsGenerationProcess()
        {
            while (true)
            {
                for (int i = 0; i < Random.Range(_minSpawnAmount, _maxSpawnAmount); i++)
                {
                    float initial = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
                    
                    float randomX = Random.Range(
                        initial * 1.15f,
                        initial * 1.75f
                    );

                    float randomY = Random.Range(
                        _minCloudsSpawnPoint,
                        _maxCloudsSpawnPoint
                    );

                    int randomZ = Random.Range(-10, -1);

                    CloudBehaviour cloudBehaviour = Instantiate(
                        _cloudPrefabs[Random.Range(0, _cloudPrefabs.Length)],
                        new Vector3(randomX, randomY, 0),
                        Quaternion.identity
                    );

                    cloudBehaviour.transform.localScale *= 0.33f;

                    cloudBehaviour.SetupRandomOrder(randomZ);

                    _activeClouds.Add(cloudBehaviour);
                }

                yield return new WaitForSeconds(_spawnInterval);
            }
        }
    }
}
