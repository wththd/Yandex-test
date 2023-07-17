using FlappyClone.Scripts.Factories;
using FlappyClone.Scripts.UIScreens;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlappyClone.Scripts.Controllers
{
    public class GameSceneController : MonoBehaviour
    {
        [Header("UI screens")]
        [SerializeField] private PreparingScreen preparingScreen;
        [SerializeField] private PlayingScreen playingScreen;
        [SerializeField] private GameEndScreen gameEndScreen;
        [SerializeField] private PauseScreen pauseScreen;

        [Space(10)] [Header("Other variables")] 
        [SerializeField] private int prepareTime;
        [SerializeField] private int bonusSpawnCooldown;
        [SerializeField] private int obstacleSpawnCooldown;

        [Space(10)] [Header("Gameplay variables")] 
        [SerializeField] private PlayerController playerController;
        [SerializeField] private BonusFactory bonusFactory;
        [SerializeField] private ObstacleFactory obstacleFactory;

        private float lastBonusTimeSpawn;
        private float lastObstacleTimeSpawn;

        private void Awake()
        {
            DisableAllScreens();
            GameManager.GameStateChanged += OnGameStateChanged;
            GameManager.ScoreChanged += OnScoreChanged;
            GameManager.CurrentState = GameState.Preparing;
            
            playingScreen.PausePressed += PlayingScreenOnPausePressed;
            gameEndScreen.BackClicked += OnBackClicked;
            gameEndScreen.RestartClicked += OnRestartClicked;
            pauseScreen.BackPressed += OnBackClicked;
            pauseScreen.ContinuePressed += PauseScreenOnContinuePressed;
        }

        private void Update()
        {
            if (GameManager.CurrentState == GameState.Play)
            {
                if (CheckIfShouldSpawnBonus())
                {
                    var bonus = bonusFactory.Create();
                    bonus.SetPlayerTarget(playerController.transform);
                    lastBonusTimeSpawn = Time.unscaledTime;
                }

                if (CheckIfShouldSpawnObstacle())
                {
                    obstacleFactory.Create();
                    lastObstacleTimeSpawn = Time.unscaledTime;
                }
            }
        }

        private bool CheckIfShouldSpawnBonus()
        {
            return lastBonusTimeSpawn == 0 || Time.unscaledTime - lastBonusTimeSpawn > bonusSpawnCooldown;
        }
        
        private bool CheckIfShouldSpawnObstacle()
        {
            return lastObstacleTimeSpawn == 0 || Time.unscaledTime - lastObstacleTimeSpawn > obstacleSpawnCooldown;
        }

        private void PauseScreenOnContinuePressed()
        {
            PauseController.Resume();
            GameManager.CurrentState = GameState.Play;
        }

        private void OnRestartClicked()
        {
            GameManager.CurrentScore = 0;
            SceneManager.LoadScene(1);
        }

        private void OnBackClicked()
        {            
            GameManager.CurrentScore = 0;
            SceneManager.LoadScene(0);
        }

        private void PlayingScreenOnPausePressed()
        {
            GameManager.CurrentState = GameState.Pause;
        }

        private void OnScoreChanged(int score)
        {
            if (GameManager.CurrentState == GameState.Play)
            {
                playingScreen.SetScore(GameManager.CurrentScore);
            }
        }

        private void OnDestroy()
        {
            GameManager.GameStateChanged -= OnGameStateChanged;
            GameManager.ScoreChanged -= OnScoreChanged;
            
            playingScreen.PausePressed -= PlayingScreenOnPausePressed;
            gameEndScreen.BackClicked -= OnBackClicked;
            gameEndScreen.RestartClicked -= OnRestartClicked;
            pauseScreen.BackPressed -= OnBackClicked;
            pauseScreen.ContinuePressed -= PauseScreenOnContinuePressed;
        }

        private void OnGameStateChanged(GameState state)
        {
            DisableAllScreens();
            switch (state)
            {
                case GameState.Preparing:
                    preparingScreen.gameObject.SetActive(true);
                    preparingScreen.StartTimer(prepareTime, OnPrepareOver);
                    break;
                case GameState.Play:
                    playingScreen.gameObject.SetActive(true);
                    playingScreen.SetScore(GameManager.CurrentScore);
                    break;
                case GameState.Pause:
                    pauseScreen.gameObject.SetActive(true);
                    PauseController.Pause();
                    break;
                case GameState.End:
                    playerController.StopMove();
                    gameEndScreen.SetEndText(GameManager.CurrentScore, GameManager.HighScore);
                    gameEndScreen.gameObject.SetActive(true);
                    break;
            }
        }

        private void OnPrepareOver()
        {
            GameManager.CurrentState = GameState.Play;
            playerController.StartMove();
        }

        private void DisableAllScreens()
        {
            preparingScreen.gameObject.SetActive(false);
            playingScreen.gameObject.SetActive(false);
            pauseScreen.gameObject.SetActive(false);
            gameEndScreen.gameObject.SetActive(false);
        }
    }
}