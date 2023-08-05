using Managers;
using System;
using UnityEngine;
using TMPro;
using System.Collections;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [Header("Scripts Reference")]
        [SerializeField] private ScoreManager scoreManager;

        [Header("Settings Victory")]
        [SerializeField] private GameObject modalVictory;
        [SerializeField] private TextMeshProUGUI currentScoreTex;
        [SerializeField] private TextMeshProUGUI totalScoreTex;

        [Header("Settings Loser")]
        [SerializeField] private GameObject modalLoser;

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
            modalLoser.SetActive(true);
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
