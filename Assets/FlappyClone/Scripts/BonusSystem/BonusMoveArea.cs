using System;
using FlappyClone.Scripts.BonusSystem;
using UnityEngine;

public class BonusMoveArea : MonoBehaviour
{
    public event Action<Transform> EnteredPickArea;
    
    [SerializeField] private float targetDistance;
    private Transform _target;
    private bool isTriggered;
    
    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        if (ReferenceEquals(_target, null) || isTriggered)
        {
            return;
        }

        if (Vector3.Distance(transform.position, _target.position) < targetDistance)
        {
            EnteredPickArea?.Invoke(_target);
            isTriggered = true;
        }
    }
}
