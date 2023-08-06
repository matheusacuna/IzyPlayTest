using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class InventoryKnifes : MonoBehaviour
    {
        [Header("Inventory Knifes Settings")]
        public GameObject knifeOptionUIPrefab;
        public GameObject modalOptionsKnife;
        public Transform containerKnifeOptions;
        public Transform spawnTransformKnife;
        [Space(10)]
        public List<Knife> knifeList = new List<Knife>();

        void Start()
        {
            CreateDisplayOptionsKnife();
        }

        public void CreateDisplayOptionsKnife()
        {
            for (int i = 0; i < knifeList.Count; i++)
            {
                GameObject obj = Instantiate(knifeOptionUIPrefab, containerKnifeOptions);
                obj.GetComponent<SetupKnife>().knife = knifeList[i];
                obj.GetComponent<SetupKnife>().spawnTransformKnife = spawnTransformKnife;
                obj.GetComponent<SetupKnife>().modalOptionsKnife = modalOptionsKnife;
                obj.GetComponent<SetupKnife>().nameKnife.text = knifeList[i].knifeName;
            }
        }
    }
}
