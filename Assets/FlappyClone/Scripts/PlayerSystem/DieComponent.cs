using System;
using UnityEngine;

namespace FlappyClone.Scripts.Components
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class DieComponent : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Obstacle"))
            {
                Debug.Log("Died");
                Died?.Invoke();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Obstacle"))
            {
                Debug.Log("Died");
                Died?.Invoke();
            }
        }

        public event Action Died;
    }
}