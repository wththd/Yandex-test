using FlappyClone.Scripts.Components;
using UnityEngine;

namespace FlappyClone.Scripts.Controllers
{
    public class PlayerController : MonoBehaviour, IPausable
    {
        [SerializeField] private GravityComponent gravityComponent;
        [SerializeField] private DieComponent dieComponent;

        private void Awake()
        {
            dieComponent.Died += OnDie;
            PauseController.RegisterPausable(this);
        }

        private void OnDestroy()
        {
            dieComponent.Died -= OnDie;
            PauseController.UnregisterPausable(this);
        }

        public void StartMove()
        {
            gravityComponent.SetMoveState(true);
        }

        public void StopMove()
        {
            gravityComponent.SetMoveState(false);
        }

        private void OnDie()
        {
            GameManager.CurrentState = GameState.End;
        }

        public void Pause()
        {
            StopMove();
        }

        public void Resume()
        {
            StartMove();
        }
    }
}