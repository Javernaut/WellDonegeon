using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace WellDonegeon
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 10;
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
            var actualMoveAmount = new Vector3(_moveAmount.x, 0, _moveAmount.y);
            _myRigidbody.velocity = moveSpeed * actualMoveAmount;
        }
    }
}