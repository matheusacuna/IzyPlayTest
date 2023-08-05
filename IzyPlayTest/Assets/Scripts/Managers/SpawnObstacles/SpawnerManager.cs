using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class SpawnerManager : MonoBehaviour
    {
        public List<Transform> wayPoints = new List<Transform>();
        public GameObject prefabObstacle;

        private void Start()
        {
            SpawnObstacles();
        }
        public void SpawnObstacles()
        {
            for (int i = 0; i < wayPoints.Count + 1; i++)
            {
                Instantiate(prefabObstacle, wayPoints[Random.Range(0, wayPoints.Count)].position, transform.rotation);
            }
        }
    }
}

