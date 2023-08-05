using Managers;
using System;
using UnityEngine;
using TMPro;
using System.Collections;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        [Header("Scripts Reference")]
        [SerializeField] private ScoreManager scoreManager;

        [Header("Settings Victory")]
        [SerializeField] private GameObject modalVictory;
        [SerializeField] private TextMeshProUGUI currentScoreTex;
        [SerializeField] private TextMeshProUGUI totalScoreTex;

        public static Action ACT_VictoryGame;
        public static Action ACT_LoserGame;
        private void OnEnable()
        {
            ACT_VictoryGame += VictoryGame;
            ACT_LoserGame += LoserGame;
        }

        private void OnDisable()
        {
            ACT_VictoryGame -= VictoryGame;
            ACT_LoserGame -= LoserGame;
        }
        public void VictoryGame()
        {
            StartCoroutine(ModalVictoryGame());
        }

        public void LoserGame()
        {
            Debug.Log("poxa vc perdeu");
        }

        public IEnumerator ModalVictoryGame()
        {
            modalVictory.SetActive(true);
            yield return new WaitForSeconds(1f);
            currentScoreTex.text = scoreManager.currentScore.ToString();
            totalScoreTex.text = scoreManager.finalScore.ToString();

        }
    }
}
