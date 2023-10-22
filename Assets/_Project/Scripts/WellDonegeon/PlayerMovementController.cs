using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace WellDonegeon
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovementController : MonoBehaviour
    {
        private static readonly int Velocity = Animator.StringToHash("Velocity");
        
        [SerializeField] private float moveSpeed = 10;

        // Per sec
        [SerializeField] private float rotateSpeed = 180f;
        [SerializeField] private Animator animator;

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

        private void FixedUpdate()
        {
            if (_moveAmount.magnitude > Mathf.Epsilon)
            {
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
            
            animator.SetFloat(Velocity, _myRigidbody.velocity.magnitude);
        }
    }
}