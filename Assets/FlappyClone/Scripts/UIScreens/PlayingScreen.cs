using System;
using TMPro;
using UnityEngine;

namespace FlappyClone.Scripts.UIScreens
{
    public class PlayingScreen : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI scoreText;
        public event Action PausePressed;

        private int currentScore = -1;

        public void SetScore(int score)
        {
            if (currentScore != score)
            {
                currentScore = score;
                scoreText.text = currentScore.ToString();
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnPausePressed();
            }
        }

        public void OnPausePressed()
        {
            PausePressed?.Invoke();
        }
    }
}