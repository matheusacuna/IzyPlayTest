using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class SpawnerManager : MonoBehaviour
    {
        public List<Transform> wayPoints = new List<Transform>();
        public List<GameObject> poolObjects = new List<GameObject>();
        public GameObject prefabObstacle;

        private void Start()
        {
            SpawnObstacles();

        }
        public void SpawnObstacles()
        {            
            poolObjects.Clear();

            List<int> usedIndices = new List<int>(); 

            for (int i = 0; i < wayPoints.Count; i++)
            {
                int randomIndex = Random.Range(0, wayPoints.Count);
                
                while (usedIndices.Contains(randomIndex))
                {
                    randomIndex = Random.Range(0, wayPoints.Count);
                }

                usedIndices.Add(randomIndex); 

                GameObject obj = Instantiate(prefabObstacle, wayPoints[randomIndex].position, transform.rotation);
                poolObjects.Add(obj);
            }
        }
    }
}

