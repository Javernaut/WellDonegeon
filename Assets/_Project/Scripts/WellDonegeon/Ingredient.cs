using UnityEngine;

namespace WellDonegeon
{
    [CreateAssetMenu]
    public class Ingredient : ScriptableObject
    {
        [SerializeField] private GameObject ingredientModel;
    }
}