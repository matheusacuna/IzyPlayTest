using System;
using UnityEngine;
using TMPro;
using System.Collections;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        [Header("Score Settings")]
        public int currentScore;
        public int finalScore;
        public TextMeshProUGUI scoreText;

        public static Action<int> ACT_IncrementScore;
        public static Action<int> ACT_ScoreFinal;
        private void Update()
        {
            scoreText.text = currentScore.ToString();
        }

        private void OnEnable()
        {
            ACT_IncrementScore += IncrementScore;
            ACT_ScoreFinal += ScoreFinal;
        }

        private void OnDisable()
        {
            ACT_IncrementScore -= IncrementScore;
            ACT_ScoreFinal -= ScoreFinal;
        }

        public void IncrementScore(int value)
        {
            currentScore += value;
            //Vector3 originalScale = scoreText.transform.localScale;
            //scoreText.transform.DOPunchScale(new Vector3(2, 2, 2), .2f);
            //scoreText.transform.DOScale(originalScale, .2f).SetDelay(.2f);
        }

        //public void ScoreFinalAction(int multiplier)
        //{
        //    StartCoroutine(ScoreFinal(multiplier));
        //}

        public void ScoreFinal(int multiplier)
        {
            finalScore = currentScore * multiplier;
        }
    }
}

