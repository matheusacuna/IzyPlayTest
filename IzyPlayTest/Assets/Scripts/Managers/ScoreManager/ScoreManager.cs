using System;
using UnityEngine;
using TMPro;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        [Header("Score Settings")]
        [SerializeField] private int currentScore;
        [SerializeField] private int finalScore;
        public TextMeshProUGUI scoreText;

        public static Action<int> ACT_IncrementScore;
        private void Update()
        {
            scoreText.text = currentScore.ToString();
        }

        private void OnEnable()
        {
            ACT_IncrementScore += IncrementScore;
        }

        private void OnDisable()
        {
            ACT_IncrementScore -= IncrementScore;
        }

        public void IncrementScore(int value)
        {
            currentScore += value;
            //Vector3 originalScale = scoreText.transform.localScale;
            //scoreText.transform.DOPunchScale(new Vector3(2, 2, 2), .2f);
            //scoreText.transform.DOScale(originalScale, .2f).SetDelay(.2f);
        }

        public void ScoreFinal(int multiplier)
        {
            finalScore = currentScore * multiplier;
        }
    }
}

