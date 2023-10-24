using UnityEngine;

namespace WellDonegeon
{
    public class SimpleTable : MonoBehaviour, IInteractable, ITransferParty
    {
        [SerializeField] private Transform itemSlot;

        private IHoldable _item;
        
        public ITransferParty GetTransferParty()
        {
            return this;
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