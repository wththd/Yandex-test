using UnityEngine;

namespace FlappyClone.Scripts.Components
{
    [RequireComponent(typeof(RectTransform))]
    public class GravityComponent : MonoBehaviour
    {
        [SerializeField] private float jumpStrength;
        private bool isMoving;
        private Rigidbody2D rigidBody;

        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody2D>();
            isMoving = false;
        }

        private void Update()
        {
            if (!isMoving) return;

            if (CheckIfJumpButtonPressed()) rigidBody.velocity = Vector2.up * jumpStrength;

            transform.eulerAngles = new Vector3(0, 0, rigidBody.velocity.y);
        }

        private bool CheckIfJumpButtonPressed()
        {
            return Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);
        }

        public void SetMoveState(bool state)
        {
            rigidBody.bodyType = state ? RigidbodyType2D.Dynamic : RigidbodyType2D.Static;
            isMoving = state;
        }
    }
}