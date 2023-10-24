using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace WellDonegeon
{
    [RequireComponent(typeof(Highlighter))]
    public class ServingArea : MonoBehaviour, IInteractable
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        private Highlighter _highlighter;
        
        private int _score;

        private void Awake()
        {
            _highlighter = GetComponent<Highlighter>();
        }
        
        public ITransferParty GetTransferParty()
        {
            return new TransferParty(this);
        }

        public void SetSelected(bool selected)
        {
            _highlighter.SetHighlighted(selected);
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