using TMPro;
using UnityEngine;

namespace WellDonegeon
{
    public class ServingArea : BaseInteractableThing
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        private int _score;

        public override ITransferParty GetTransferParty()
        {
            return new TransferParty(this);
        }

        // Currently accepting whatever we are given
        private class TransferParty : ITransferParty
        {
            private readonly ServingArea _servingArea;

            public TransferParty(ServingArea servingArea)
            {
                _servingArea = servingArea;
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