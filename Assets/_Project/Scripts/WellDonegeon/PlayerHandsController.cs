using UnityEngine;
using UnityEngine.InputSystem;

namespace WellDonegeon
{
    public class PlayerHandsController : MonoBehaviour, ITransferParty
    {
        [SerializeField] private Transform handsTransform;

        private IHoldable _holdable;

        private IInteractable _interactable;

        private void FixedUpdate()
        {
            IInteractable newInteractable = null;
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(
                    transform.position + Vector3.up,
                    transform.TransformDirection(Vector3.forward),
                    out hit,
                    1))
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
            if (_interactable != null)
            {
                TransferProcessor.Transfer(this, _interactable.GetTransferParty());
                _interactable.OnTransferDone();
            }
        }

        private void SetSelectedInteractable(IInteractable interactable)
        {
            if (_interactable != interactable)
            {
                _interactable?.SetSelected(false);
                _interactable = interactable;
                _interactable?.SetSelected(true);    
            }
        }

        public IHoldable GetHoldable()
        {
            return _holdable;
        }

        public void SetHoldable(IHoldable holdable)
        {
            _holdable = holdable;
        }

        public void NotifyHoldableChanged()
        {
            if (handsTransform.childCount > 0)
            {
                Destroy(handsTransform.GetChild(0).gameObject);
            }

            _holdable?.RenderAt(handsTransform);
        }

        public IHoldable PeekHoldable()
        {
            return _holdable;
        }

        public void PopHoldable()
        {
            _holdable = null;
        }

        public void PushHoldable(IHoldable holdable)
        {
            _holdable = holdable;
        }

        public bool CanAccept(IHoldable holdable)
        {
            // Only if there is no holdable at hands
            return _holdable == null;
        }
    }
}