using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Managers
{
    public class SpawnerManager : MonoBehaviour
    {
        public List<Transform> wayPoints = new List<Transform>();
        private List<GameObject> instantiatedObstacles = new List<GameObject>();

        public Dictionary<string, GameObject> resources;

        private void Awake()
        {
            StartCoroutine(InitializeLoadPathAssets());
        }

        public void Start()
        {
            StartCoroutine(SpawnObstacles());
        }

        public void DestroyAllObstacles()
        {
            foreach (var obstacle in instantiatedObstacles)
            {
                Addressables.ReleaseInstance(obstacle);

                Destroy(obstacle);
            }

            instantiatedObstacles.Clear();
        }

        public IEnumerator InitializeLoadPathAssets()
        {
            resources = new Dictionary<string, GameObject>();

            AsyncOperationHandle<IList<GameObject>> handle = Addressables.LoadAssetsAsync<GameObject>("tables", null);
            yield return handle;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                IList<GameObject> loadedObjects = handle.Result;

                foreach (GameObject obj in loadedObjects)
                {

                    if (!resources.ContainsKey(obj.name))
                    {
                        resources.Add(obj.name, obj);
                    }
                }
            }
        }


        public IEnumerator SpawnObstacles()
        {
            while (resources == null)
            {
                yield return null;
            }

            var handle = Addressables.LoadAssetAsync<GameObject>("tables");
            yield return handle;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                GameObject prefabObstacle = handle.Result;

                List<int> usedIndices = new List<int>();

                for (int i = 0; i < wayPoints.Count; i++)
                {
                    int randomIndex = Random.Range(0, wayPoints.Count);

                    while (usedIndices.Contains(randomIndex))
                    {
                        randomIndex = Random.Range(0, wayPoints.Count);
                    }

                    usedIndices.Add(randomIndex);

                    GameObject prefabObstacleInstantieded = Instantiate(prefabObstacle, wayPoints[randomIndex].position, transform.rotation);
                    instantiatedObstacles.Add(prefabObstacleInstantieded);
                }
            }
        }
    }
}







