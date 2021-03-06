using System;
using UnityEngine;

namespace _TestObject
{
    /// <summary>
    /// Uv에 따라 색 변함
    /// </summary>
    public class UVFeature : TestObjectFeature
    {
        [SerializeField] private CollisionCaster caster;
        [SerializeField] private LayerMask uvLayer;
        [SerializeField] private bool changeColorOnDefect;//normal일시 색이 변하는가? defect일시 색이 변하는가?
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private Color uvColor = Color.blue;
        [SerializeField]
        private Color m_OldColor;

        private bool isChangeColor => changeColorOnDefect == IsDefect;

        

        private void Start()
        {
            caster.onTriggerEnter += OnUvEnter;
            caster.onTriggerExit += OnUvExit;
            var mat = meshRenderer.material;
            m_OldColor = mat.color;
        }

        private void OnUvEnter(Collider other)
        {
            if(!isChangeColor)
                return;
            
            if(Tools.IsInLayerMask(other.gameObject.layer,uvLayer))
                ChangeColorByChange(uvColor);
        }

        private void OnUvExit(Collider other)
        {
            if(Tools.IsInLayerMask(other.gameObject.layer,uvLayer)) 
                ChangeColorOld(m_OldColor);
        }
        
        private void ChangeColorOld(Color color)
        {
            var mat = meshRenderer.material;
            mat.color = m_OldColor;
        }
        private void ChangeColorByChange(Color color)
        {
            var mat = meshRenderer.material;
            mat.color = uvColor;
        }

    }
}