using System;
using UnityEngine;
using TMPro;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        [Header("Score Settings")]
        public int currentScore;
        public int finalScore;
        public TextMeshProUGUI scoreText;

        //Actions criadas com intuitio de chamar suas respectivas funções nos Scripts desejados sem precisar referenciá-los.
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

        //Incrementa pontos para o player.
        public void IncrementScore(int value)
        {
            currentScore += value;
        }

        //Calcula a pontuação final dependendo do valor passando no parâmetro multiplier.
        public void ScoreFinal(int multiplier)
        {
            finalScore = currentScore * multiplier;
        }
    }
}

