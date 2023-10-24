using System;
using UnityEngine;

namespace WellDonegeon
{
    public class Highlighter : MonoBehaviour
    {
        [SerializeField] private Renderer renderer;
        [SerializeField] private Color color = Color.white;

        public void SetHighlighted(bool selected)
        {
            var material = renderer.material;
            if (selected)
            {
                material.EnableKeyword("_EMISSION");
                //before we can set the color
                material.SetColor("_EmissionColor", color);
            }
            else
            {
                material.DisableKeyword("_EMISSION");
            }
        }
    }
}