using UnityEngine;

namespace _TestObject
{
    /// <summary>
    /// Defect일시 mesh의 color가 wrong color
    /// </summary>
    public class MeshColorFeature : TestObjectFeature
    {
        [SerializeField] private MeshRenderer meshRenderer;
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