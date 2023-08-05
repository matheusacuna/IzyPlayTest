using Managers;
using UnityEngine;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        [Header("Scripts Reference")]
        [SerializeField] private ScoreManager scoreManager;

        public void VictoryGame()
        {
            
        }

        public void LoserGame()
        {
            Debug.Log("poxa vc perdeu");
        }

        public void ModalVictoryGame()
        {

        }
    }
}
