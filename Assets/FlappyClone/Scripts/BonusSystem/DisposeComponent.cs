using System;
using UnityEngine;

namespace FlappyClone.Scripts.BonusSystem
{
    public class DisposeComponent : MonoBehaviour
    {
        public event Action DisposeTriggered;
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Dispose"))
            {
                DisposeTriggered?.Invoke();
            }
        }
    }
}