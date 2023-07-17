using System;
using UnityEngine;

namespace FlappyClone.Scripts.BonusSystem
{
    public class BonusPickComponent : MonoBehaviour
    {
        public event Action Picked;
        
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Picked?.Invoke();
            }
        }
    }
}