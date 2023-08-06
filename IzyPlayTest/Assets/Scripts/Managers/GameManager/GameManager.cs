using Managers;
using System;
using UnityEngine;
using TMPro;
using System.Collections;
using Player;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [Header("Scripts Reference")]
        [SerializeField] private ScoreManager scoreManager;
        public GameObject rotationKnife;

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
            DisableKnifeComponente();
        }

        public void LoserGame()
        {
            modalLoser.SetActive(true);
            DisableKnifeComponente();
        }

        public IEnumerator ModalVictoryGame()
        {
            modalVictory.SetActive(true);
            SoundManager.PlaySoundEffect(SoundsType.SoundEffect, "VictoryGame");
            yield return new WaitForSeconds(1f);
            currentScoreTex.text = scoreManager.currentScore.ToString();
            totalScoreTex.text = scoreManager.finalScore.ToString();
        }

        private void DisableKnifeComponente()
        {
            rotationKnife.GetComponent<RotationKnife>().enabled = false;
        }

        public void ChangeTimeScale(float valueTime)
        {
            Time.timeScale = valueTime;
        }
    }
}
