using TMPro;
using UnityEngine;

namespace WellDonegeon
{
    public class ServingArea : MonoBehaviour, IInteractable
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        private int _score;

        public void Transfer(PlayerHandsController playerHandsController)
        {
            if (playerHandsController.Ingredient != null)
            {
                _score++;
                scoreText.text = _score.ToString();

                playerHandsController.IngredientTakenAway();
            }
        }
    }
}