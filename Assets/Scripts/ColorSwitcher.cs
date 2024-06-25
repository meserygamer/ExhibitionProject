using UnityEngine;

namespace Scripts
{
    public sealed class ColorSwitcher : MonoBehaviour
    {
        [SerializeField] private Material _errorMaterial;
        [SerializeField] private Material _rightMaterial;
        [SerializeField] private uint _materialIndex;

        private MeshRenderer _meshRenderer;


        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }


        public void SwitchToErrorColor()
        {
            Material[] materials = _meshRenderer.materials;
            materials[_materialIndex] = _errorMaterial;
            _meshRenderer.materials = materials;
        }

        public void SwitchToRightColor()
        {
            Material[] materials = _meshRenderer.materials;
            materials[_materialIndex] = _rightMaterial;
            _meshRenderer.materials = materials;
        }
    }
}