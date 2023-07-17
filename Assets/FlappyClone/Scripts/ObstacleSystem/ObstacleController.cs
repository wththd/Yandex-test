using System;
using FlappyClone.Scripts;
using FlappyClone.Scripts.BonusSystem;
using FlappyClone.Scripts.Controllers;
using UnityEngine;

public class ObstacleController : MonoBehaviour, IPausable
{
    [SerializeField] private ObstacleMoveComponent obstacleMoveComponent;
    [SerializeField] private DisposeComponent disposeComponent;
    private void Awake()
    {
        GameManager.GameStateChanged += GameManagerOnGameStateChanged;
        disposeComponent.DisposeTriggered += OnDisposeTriggered;
        GameManagerOnGameStateChanged(GameManager.CurrentState);
    }

    private void Start()
    {
        obstacleMoveComponent.GenerateRandomPosition();
    }

    private void OnDisposeTriggered()
    {
        DestroyObstacle();
    }

    private void GameManagerOnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.Play:
                obstacleMoveComponent.SetMoveState(true);
                break;
            default:
                obstacleMoveComponent.SetMoveState(false);
                break;
        }
    }
    private void DestroyObstacle()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        PauseController.UnregisterPausable(this);
        GameManager.GameStateChanged -= GameManagerOnGameStateChanged;
    }

    public void Pause()
    {
        obstacleMoveComponent.SetMoveState(false);
    }

    public void Resume()
    {
        obstacleMoveComponent.SetMoveState(true);
    }
}
