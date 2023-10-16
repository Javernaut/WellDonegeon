using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace WellDonegeon
{
    public class PlayerHandsController : MonoBehaviour
    {
        [SerializeField] private Transform handsTransform;
        
        private Ingredient _ingredient;

        public Ingredient Ingredient => _ingredient;

        private IInteractable _interactable;

        public void PickIfNotEmpty(Ingredient ingredient)
        {
            if (_ingredient == null)
            {
                _ingredient = ingredient;
                Debug.Log("Ingredient picked");
                ingredient.SpawnAt(handsTransform);
            }
        }

        public void IngredientTakenAway()
        {
            _ingredient = null;
            // Assume we have only 1 child
            Destroy(handsTransform.GetChild(0).gameObject);
            Debug.Log("Ingredient taken away");
        }
        
        private void FixedUpdate()
        {
            IInteractable newInteractable = null;
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(
                    transform.position + Vector3.up,
                    transform.TransformDirection(Vector3.forward),
                    out hit,
                    3))
            {
                if (hit.transform.gameObject.TryGetComponent<IInteractable>(out var interactable))
                {
                    newInteractable = interactable;
                }
            }

            SetSelectedInteractable(newInteractable);
        }

        public void OnTransfer(InputValue value)
        {
            _interactable?.Transfer(this);
        }

        private void SetSelectedInteractable(IInteractable interactable)
        {
            // _interactable?.SetSelected(false);
            _interactable = interactable;
            // _interactable?.SetSelected(true);
        }
    }
}