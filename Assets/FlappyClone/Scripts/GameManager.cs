using System;
using UnityEngine;

namespace FlappyClone.Scripts
{
    public static class GameManager
    {
        public static event Action<GameState> GameStateChanged;
        public static event Action<int> ScoreChanged;
        
        private static GameState currentState;
        private static int currentScore;

        private const string HighScoreSaveKey = "HighScore";

        public static GameState CurrentState
        {
            get => currentState;
            set
            {
                currentState = value;
                GameStateChanged?.Invoke(currentState);
            }
        }

        public static int CurrentScore
        {
            get => currentScore;
            set
            {
                currentScore = value;
                ScoreChanged?.Invoke(currentScore);
            }
        }

        public static int HighScore
        {
            get
            {
                var savedScore = PlayerPrefs.HasKey(HighScoreSaveKey) ? PlayerPrefs.GetInt(HighScoreSaveKey) : 0;
                if (CurrentScore > savedScore)
                {
                    PlayerPrefs.SetInt(HighScoreSaveKey, CurrentScore);
                    PlayerPrefs.Save();
                    return CurrentScore;
                }

                return savedScore;
            }
        }


    }
}