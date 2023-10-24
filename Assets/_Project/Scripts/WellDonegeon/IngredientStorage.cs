using UnityEngine;

namespace WellDonegeon
{
    [RequireComponent(typeof(Highlighter))]
    public class IngredientStorage : MonoBehaviour, IInteractable
    {
        [SerializeField] private Ingredient ingredient;

        private Highlighter _highlighter;
        
        private void Awake()
        {
            _highlighter = GetComponent<Highlighter>();
        }
        
        public ITransferParty GetTransferParty()
        {
            return new TransferParty(ingredient);
        }

        public void SetSelected(bool selected)
        {
            _highlighter.SetHighlighted(selected);
        }

        private class TransferParty : ITransferParty
        {
            private readonly Ingredient _ingredient;

            public TransferParty(Ingredient ingredient)
            {
                _ingredient = ingredient;
            }

            public void NotifyHoldableChanged()
            {
            }

            public IHoldable PeekHoldable()
            {
                return _ingredient;
            }

            public void PopHoldable()
            {
            }

            public void PushHoldable(IHoldable holdable)
            {
                // Not supported
            }

            public bool CanAccept(IHoldable holdable) => false;
        }
    }
}