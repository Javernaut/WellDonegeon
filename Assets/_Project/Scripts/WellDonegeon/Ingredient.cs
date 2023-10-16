using UnityEngine;

namespace WellDonegeon
{
    [CreateAssetMenu]
    public class Ingredient : ScriptableObject
    {
        [SerializeField] private GameObject ingredientModel;

        public void SpawnAt(Transform parent)
        {
            Instantiate(ingredientModel, parent);
        }
    }
}