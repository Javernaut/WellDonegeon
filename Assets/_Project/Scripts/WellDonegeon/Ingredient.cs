using UnityEngine;

namespace WellDonegeon
{
    [CreateAssetMenu]
    public class Ingredient : ScriptableObject, IHoldable
    {
        [SerializeField] private GameObject ingredientModel;

        public void RenderAt(Transform parent)
        {
            Instantiate(ingredientModel, parent);
        }
    }
}