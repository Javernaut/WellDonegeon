using System;
using UnityEngine;

namespace WellDonegeon
{
    public interface IInteractable
    {
        // Should be non-null
        public ITransferParty GetTransferParty();
        // TODO
        // public SetSelected(byWho, isSelected);
    }

    public class TransferProcessor
    {
        public static void Transfer(ITransferParty player, ITransferParty other)
        {
            // TODO Should I use some locks here to prevent other player to intrude?
            var playerBurden = player.PeekHoldable();
            var otherBurden = other.PeekHoldable();

            if (other.CanAccept(playerBurden))
            {
                other.PushHoldable(playerBurden);
                player.PopHoldable();

                player.NotifyHoldableChanged();
                other.NotifyHoldableChanged();
            }
            else if (player.CanAccept(otherBurden))
            {
                player.PushHoldable(otherBurden);
                other.PopHoldable();

                other.NotifyHoldableChanged();
                player.NotifyHoldableChanged();
            }
        }
    }

    // Dishes, raw/cut ingredients, fire extinguisher
    public interface IHoldable
    {
        void RenderAt(Transform parent);
    }

    public interface ITransferParty
    {
        // Getting the top Holdable without removing it
        IHoldable PeekHoldable();

        // Getting the top holdable and removing it
        IHoldable PopHoldable();

        // Pushing the holdable, assume it will be accepted
        void PushHoldable(IHoldable holdable);
        bool CanAccept(IHoldable holdable);
        void NotifyHoldableChanged();
    }

    // class SimpleTable : MonoBehaviour, IInteractable
    // {
    //     public void Transfer(PlayerHandsController playerHandsController)
    //     {
    //     }
    // }
}