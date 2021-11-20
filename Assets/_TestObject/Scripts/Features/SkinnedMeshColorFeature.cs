using UnityEngine;

namespace _TestObject
{
    public class SkinnedMeshColorFeature : TestObjectFeature
    {
        [SerializeField] private SkinnedMeshRenderer meshRenderer;
        [SerializeField] private Color wrongColor = Color.yellow;
        
        protected override void OnNormal()
        {
            meshRenderer.material.color = Color.white;
        }
        protected override void OnDefect()
        {
            meshRenderer.material.color = wrongColor;
        }
    }
}