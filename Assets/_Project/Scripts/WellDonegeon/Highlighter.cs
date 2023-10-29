using System.Collections.Generic;
using UnityEngine;

namespace WellDonegeon
{
    /// <summary>
    /// Component that highlights a hierarchy of objects displaying its 'selected' state.
    /// </summary>
    public class Highlighter : MonoBehaviour
    {
        private bool _isHighlighted;
        private List<Material> materials;

        // TODO Inject via DI
        [SerializeField] private Color color = Color.white;

        private void Awake()
        {
            RefreshSelf();
        }

        /// <summary>
        /// Refreshes the parts to highlight.
        /// Should be called once a GameObject with this Highlighter gets or loses a child/nested child object.  
        /// </summary>
        public void RefreshSelf()
        {
            materials = GetAllMaterials(gameObject);
            SetHighlighted(_isHighlighted);
        }

        public void SetHighlighted(bool selected)
        {
            _isHighlighted = selected;
            foreach (var material in materials)
            {
                if (selected)
                {
                    material.EnableKeyword("_EMISSION");
                    material.SetColor("_EmissionColor", color);
                }
                else
                {
                    material.DisableKeyword("_EMISSION");
                }
            }
        }

        private static List<Material> GetAllMaterials(GameObject go)
        {
            var result = new List<Material>();
            GetAllMaterials(go, result);
            return result;
        }

        private static void GetAllMaterials(GameObject go, List<Material> accumulator)
        {
            if (go.TryGetComponent(out Renderer currentRenderer))
            {
                // Assume only a single material per renderer
                var material = currentRenderer.material;
                if (material != null)
                {
                    accumulator.Add(material);
                }
            }

            foreach (Transform childTransform in go.transform)
            {
                GetAllMaterials(childTransform.gameObject, accumulator);
            }
        }
    }
}