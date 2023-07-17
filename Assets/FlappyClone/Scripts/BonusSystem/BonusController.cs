using System;
using FlappyClone.Scripts.Controllers;
using UnityEngine;

namespace FlappyClone.Scripts.BonusSystem
{
    public class BonusController : MonoBehaviour, IPausable
    {
        [SerializeField] private BonusMoveArea moveArea;
        [SerializeField] private BonusPickComponent pickComponent;
        [SerializeField] private BonusMoveComponent moveComponent;
        [SerializeField] private DisposeComponent disposeComponent;

        private void Awake()
        {
            PauseController.RegisterPausable(this);
            GameManager.GameStateChanged += GameManagerOnGameStateChanged;
            moveArea.EnteredPickArea += OnEnteredPickArea;
            pickComponent.Picked += OnPicked;
            disposeComponent.DisposeTriggered += OnDisposeTriggered;
            GameManagerOnGameStateChanged(GameManager.CurrentState);
        }

        private void Start()
        {
            moveComponent.GenerateRandomPosition();
        }

        private void OnDisposeTriggered()
        {
            DestroyBonus();
        }

        public void SetPlayerTarget(Transform target)
        {
            moveArea.SetTarget(target);
        }

        private void GameManagerOnGameStateChanged(GameState state)
        {
            switch (state)
            {
                case GameState.Play:
                    moveComponent.SetMoveState(true);
                    break;
                default:
                    moveComponent.SetMoveState(false);
                    break;
            }
        }

        private void OnPicked()
        {
            GameManager.CurrentScore++;
            DestroyBonus();
        }

        private void OnEnteredPickArea(Transform target)
        {
            moveComponent.MoveTo(target);
        }

        private void DestroyBonus()
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            PauseController.UnregisterPausable(this);
            GameManager.GameStateChanged -= GameManagerOnGameStateChanged;
            moveArea.EnteredPickArea -= OnEnteredPickArea;
            pickComponent.Picked -= OnPicked;
        }

        public void Pause()
        {
            moveComponent.SetMoveState(false);
        }

        public void Resume()
        {
            moveComponent.SetMoveState(true);
        }
    }
}