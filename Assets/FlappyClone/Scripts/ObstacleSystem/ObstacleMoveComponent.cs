using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleMoveComponent : MonoBehaviour
{
    [SerializeField] private float worldHorizontalMoveSpeed;
    [SerializeField] private float worldVerticalMoveSpeed;
    [SerializeField] private float upperBound;
    [SerializeField] private float bottomBound;
    private bool isMoving;
    private bool isMovingUp;

    public void SetMoveState(bool state)
    {
        isMoving = state;
    }
    
    public void GenerateRandomPosition()
    {
        var generatedPosition = transform.position;
        generatedPosition.y = Random.Range(bottomBound, upperBound);
        var middlePoint = (upperBound + bottomBound) / 2;
        transform.position = generatedPosition;
        isMovingUp = generatedPosition.y > middlePoint;
    }

    private void Update()
    {
        if (!isMoving)
        {
            return;
        }

        SetVerticalDirection();
        transform.Translate(new Vector3(-worldHorizontalMoveSpeed, isMovingUp ? worldVerticalMoveSpeed : -worldVerticalMoveSpeed) * Time.deltaTime);
    }

    private void SetVerticalDirection()
    {
        var yPos = transform.position.y;
        if (isMovingUp && yPos >= upperBound)
        {
            isMovingUp = false;
        }

        if (!isMovingUp && yPos <= bottomBound)
        {
            isMovingUp = true;
        }
    }
}
