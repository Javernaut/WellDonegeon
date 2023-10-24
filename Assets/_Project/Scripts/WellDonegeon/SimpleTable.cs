using System;
using UnityEngine;

namespace WellDonegeon
{
    [RequireComponent(typeof(Highlighter))]
    public class SimpleTable : MonoBehaviour, IInteractable, ITransferParty
    {
        [SerializeField] private Transform itemSlot;

        private Highlighter _highlighter;

        private IHoldable _item;

        private void Awake()
        {
            _highlighter = GetComponent<Highlighter>();
        }

        public ITransferParty GetTransferParty()
        {
            return this;
        }

        public void SetSelected(bool selected)
        {
            _highlighter.SetHighlighted(selected);
        }

        public IHoldable PeekHoldable()
        {
            return _item;
        }

        public void PopHoldable()
        {
            _item = null;
        }

        public void PushHoldable(IHoldable holdable)
        {
            _item = holdable;
        }

        public bool CanAccept(IHoldable holdable)
        {
            return _item == null;
        }

        public void NotifyHoldableChanged()
        {
            if (itemSlot.childCount > 0)
            {
                Destroy(itemSlot.GetChild(0).gameObject);
            }

            _item?.RenderAt(itemSlot);
        }
    }
}