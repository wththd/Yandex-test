using FlappyClone.Scripts.BonusSystem;
using UnityEngine;

namespace FlappyClone.Scripts.Factories
{
    public class BonusFactory : MonoBehaviour
    {
        [SerializeField] private Transform bonusTransform;
        [SerializeField] private BonusController bonusPrefab;

        public BonusController Create()
        {
            var bonus = Instantiate(bonusPrefab, bonusTransform);
            bonus.transform.position = bonusTransform.position;
            return bonus;
        }
    }
}