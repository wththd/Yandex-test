using System;
using TMPro;
using UnityEngine;

namespace FlappyClone.Scripts.UIScreens
{
    public class GameEndScreen : MonoBehaviour
    {
        public event Action BackClicked;
        public event Action RestartClicked;
        
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI highScoreText;

        private const string ScoreTextPattern = "Your Score is {0}";
        private const string HighScoreTextPattern = "High Score is {0}";

        public void SetEndText(int score, int highScore)
        {
            scoreText.text = string.Format(ScoreTextPattern, score);
            highScoreText.text = string.Format(HighScoreTextPattern, highScore);
        }

        public void OnBackClick()
        {
            BackClicked?.Invoke();
        }

        public void OnRestartClick()
        {
            RestartClicked?.Invoke();
        }
    }
}