using UnityEngine;
using UnityEngine.Serialization;

namespace FlappyClone.Scripts.BonusSystem
{
    public class BonusMoveComponent : MonoBehaviour
    {
        [SerializeField] private float targetMoveSpeed;
        [SerializeField] private float worldMoveSpeed;
        [SerializeField] private float upperBound;
        [SerializeField] private float bottomBound;

        private Transform _target;
        private bool isMoving;
        
        public void MoveTo(Transform target)
        {
            _target = target;
        }

        public void GenerateRandomPosition()
        {
            var generatedPosition = transform.position;
            generatedPosition.y = Random.Range(bottomBound, upperBound);
            transform.position = generatedPosition;
        }

        public void SetMoveState(bool state)
        {
            isMoving = state;
        }

        private void Update()
        {
            if (!isMoving)
            {
                return;
            }
            if (ReferenceEquals(_target,null))
            {
                transform.Translate(Vector3.left * (worldMoveSpeed * Time.deltaTime));
                return;
            }
            
            var targetVector = (_target.position - transform.position).normalized;
            transform.Translate(targetVector * (targetMoveSpeed * Time.deltaTime));
        }
    }
}