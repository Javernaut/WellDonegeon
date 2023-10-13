using System;
using UnityEngine;

namespace WellDonegeon
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField] private Material selectedMaterial;
        [SerializeField] private Material unselectedMaterial;
        
        private MeshRenderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
        }

        public string GetName()
        {
            return name;
        }

        public void SetSelected(bool selected)
        {
            _renderer.material = selected ? selectedMaterial : unselectedMaterial;
        }
    }
}