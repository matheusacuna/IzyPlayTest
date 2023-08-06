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

        private Dictionary<string, GameObject> resources;

        private void Start()
        {
            StartCoroutine(InitializeLoadPathAssets());
        }

        //Esta fun��o destr�i todos os obstaculos instanciados.
        public void DestroyAllObstacles()
        {
            foreach (var obstacle in instantiatedObstacles)
            {
                Addressables.ReleaseInstance(obstacle);
                Destroy(obstacle);
            }

            instantiatedObstacles.Clear();
        }

        //Carrega os endere�os dos Addressables que contem a lable Obstacle
        public IEnumerator InitializeLoadPathAssets()
        {
            resources = new Dictionary<string, GameObject>();

            AsyncOperationHandle<IList<GameObject>> handle = Addressables.LoadAssetsAsync<GameObject>("Obstacle", null);
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

                StartCoroutine(SpawnObstacles());
            }
        }

        //Spawna os obst�culos que sejam referente aos endere�os que foram carregados. 
        public IEnumerator SpawnObstacles()
        {
            while (resources == null || resources.Count == 0)
            {
                yield return null;
            }

            List<int> usedIndices = new List<int>();

            foreach (Transform wayPoint in wayPoints)
            {
                int randomIndex = Random.Range(0, wayPoints.Count);

                while (usedIndices.Contains(randomIndex))
                {
                    randomIndex = Random.Range(0, wayPoints.Count);
                }

                usedIndices.Add(randomIndex);

                if (resources.Count > 0)
                {
                    string randomObstacleName = GetRandomDictionaryKey(resources);
                    GameObject prefabObstacle = resources[randomObstacleName];

                    GameObject prefabObstacleInstantieded = Instantiate(prefabObstacle, wayPoints[randomIndex].position, transform.rotation);
                    instantiatedObstacles.Add(prefabObstacleInstantieded);
                }
            }
        }

        //Obtem de forma aleat�ria uma chave do nosso dicionario possibilitando a randomiza��o no Spawn de Obstaculos
        private string GetRandomDictionaryKey(Dictionary<string, GameObject> dictionary)
        {
            int randomIndex = Random.Range(0, dictionary.Count);
            int currentIndex = 0;

            foreach (string key in dictionary.Keys)
            {
                if (currentIndex == randomIndex)
                {
                    return key;
                }

                currentIndex++;
            }

            return null;
        }
    }
}








