using UnityEngine;

namespace FlappyClone.Scripts
{
    public class ObstacleFactory : MonoBehaviour
    {
        [SerializeField] private Transform obstacleTransform;
        [SerializeField] private ObstacleController obstaclePrefab;

        public ObstacleController Create()
        {
            var obstacle = Instantiate(obstaclePrefab, obstacleTransform);
            obstacle.transform.position = obstacleTransform.position;
            return obstacle;
        }
    }
}