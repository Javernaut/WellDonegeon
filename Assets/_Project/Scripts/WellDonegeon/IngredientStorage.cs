using UnityEngine;

namespace WellDonegeon
{
    public class IngredientStorage : MonoBehaviour, IInteractable
    {
        [SerializeField] private Ingredient ingredient;

        public ITransferParty GetTransferParty()
        {
            return new TransferParty(ingredient);
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