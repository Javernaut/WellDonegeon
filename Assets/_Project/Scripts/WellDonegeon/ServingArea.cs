using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace WellDonegeon
{
    public class ServingArea : MonoBehaviour, IInteractable
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        private int _score;

        public ITransferParty GetTransferParty()
        {
            return new TransferParty(this);
        }

        // Currently accepting whatever we are given
        class TransferParty : ITransferParty
        {
            private ServingArea _servingArea;

            public TransferParty(ServingArea servingArea)
            {
                _servingArea = servingArea;
            }

            public IHoldable GetHoldable() => null;

            public void SetHoldable(IHoldable holdable)
            {
                
            }

            public void NotifyHoldableChanged()
            {
            }

            public IHoldable PeekHoldable()
            {
                return null;
            }

            public void PopHoldable()
            {
            }

            public void PushHoldable(IHoldable holdable)
            {
                _servingArea._score++;
                _servingArea.scoreText.text = _servingArea._score.ToString();
            }

            public bool CanAccept(IHoldable holdable) => holdable != null;
        }
    }
}