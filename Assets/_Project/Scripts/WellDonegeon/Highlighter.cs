using System;
using UnityEngine;

namespace WellDonegeon
{
    public class Highlighter : MonoBehaviour
    {
        [SerializeField] private Renderer[] renderers;
        [SerializeField] private Color color = Color.white;

        public void SetHighlighted(bool selected)
        {
            foreach (var subRender in renderers)
            {
                var material = subRender.material;
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
}