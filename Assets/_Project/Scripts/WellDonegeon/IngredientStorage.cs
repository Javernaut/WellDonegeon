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
            private Ingredient ingredient;

            public TransferParty(Ingredient ingredient)
            {
                this.ingredient = ingredient;
            }

            public void NotifyHoldableChanged()
            {
            }

            public IHoldable PeekHoldable()
            {
                return ingredient;
            }

            public IHoldable PopHoldable()
            {
                return ingredient;
            }

            public void PushHoldable(IHoldable holdable)
            {
                // Not supported
            }

            public bool CanAccept(IHoldable holdable) => false;
        }
    }
}