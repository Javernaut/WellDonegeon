using UnityEngine;
using UnityEngine.InputSystem;

namespace WellDonegeon
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 10;

        // Per sec
        [SerializeField] private float rotateSpeed = 180f;

        private Rigidbody _myRigidbody;
        private Vector2 _moveAmount;

        private void Awake()
        {
            _myRigidbody = GetComponent<Rigidbody>();
        }

        public void OnMove(InputValue inputValue)
        {
            _moveAmount = inputValue.Get<Vector2>();
        }

        private void Update()
        {
            if (!(_moveAmount.magnitude > Mathf.Epsilon)) return;

            // Movement
            var actualMoveAmount = new Vector3(_moveAmount.x, 0, _moveAmount.y);
            _myRigidbody.velocity = moveSpeed * actualMoveAmount;

            // Rotation
            var desiredRotation = Quaternion.LookRotation(actualMoveAmount);
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                desiredRotation,
                rotateSpeed * Time.deltaTime
            );
        }
    }
}