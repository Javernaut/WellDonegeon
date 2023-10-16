using UnityEngine;

namespace WellDonegeon
{
    public class IngredientStorage : MonoBehaviour, IInteractable
    {
        [SerializeField] private Ingredient ingredient;

        public void Transfer(PlayerHandsController playerHandsController)
        {
            playerHandsController.PickIfNotEmpty(ingredient);
        }
    }
}