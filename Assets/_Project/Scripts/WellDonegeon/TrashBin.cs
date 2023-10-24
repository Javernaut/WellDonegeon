using System;
using UnityEngine;

namespace WellDonegeon
{
    [RequireComponent(typeof(Highlighter))]
    public abstract class BaseInteractableThing : MonoBehaviour, IInteractable
    {
        private Highlighter _highlighter;

        private void Awake()
        {
            _highlighter = GetComponent<Highlighter>();
        }

        public abstract ITransferParty GetTransferParty();

        public void SetSelected(bool selected)
        {
            _highlighter.SetHighlighted(selected);
        }
    }
    
    
    public class TrashBin : BaseInteractableThing, ITransferParty
    {
        public override ITransferParty GetTransferParty()
        {
            return this;
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
            
        }

        public bool CanAccept(IHoldable holdable)
        {
            // Currently accepting everything - everything will be deleted
            return true;
        }

        public void NotifyHoldableChanged()
        {
            // Run primitive animation maybe?
        }
    }
}