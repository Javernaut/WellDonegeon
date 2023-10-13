using System;
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

        private Interactable _interactable;

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
            Interactable newInteractable = null;
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(
                    transform.position + Vector3.up,
                    transform.TransformDirection(Vector3.forward),
                    out hit,
                    2))
            {
                var interactable = hit.transform.gameObject.GetComponent<Interactable>();
                if (interactable != null)
                {
                    newInteractable = interactable;
                }
            }

            SetSelectedInteractable(newInteractable);
        }

        public void OnFire(InputValue value)
        {
            Debug.Log(_interactable == null
                ? "Nothing to interact with"
                : ("Interacted with " + _interactable.GetName()));
        }

        private void SetSelectedInteractable(Interactable interactable)
        {
            _interactable?.SetSelected(false);

            _interactable = interactable;

            _interactable?.SetSelected(true);
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