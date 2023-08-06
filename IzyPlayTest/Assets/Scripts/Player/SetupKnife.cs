using Managers;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class SetupKnife : MonoBehaviour
    {
        [Header("Knife Setup")]
        public Knife knife;
        public Transform spawnTransformKnife;
        public GameObject modalOptionsKnife;
        public Image iconColor;
        public TextMeshProUGUI nameKnife;

        private Button button;
        private MyInputsManager myInputsManager;
        private GameManager gameManager;

        private void Start()
        {
            gameManager = FindObjectOfType<GameManager>();
            myInputsManager = FindObjectOfType<MyInputsManager>();
            button = GetComponent<Button>();
            button.onClick.AddListener(InstiateKnifeObject);
        }
        public void InstiateKnifeObject()
        {
            GameObject knifePrefab = Instantiate(knife.prefabKnife, spawnTransformKnife.position, spawnTransformKnife.rotation);
            knifePrefab.GetComponent<RotationKnife>().knife = knife;
            knifePrefab.GetComponent<RotationKnife>().myInputsManager = myInputsManager;
            gameManager.rotationKnife = knifePrefab;
            modalOptionsKnife.SetActive(false);
        }
    }
}
