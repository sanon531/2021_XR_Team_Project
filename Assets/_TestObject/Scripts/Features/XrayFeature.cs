using UnityEngine;
using System.Collections;

namespace _TestObject
{
    /// <summary>
    /// 투시경
    /// </summary>
    public class XrayFeature : TestObjectFeature
    {
        [SerializeField] private GameObject handle;
        [SerializeField] private GameObject rootParent;
        [SerializeField] private MeshRenderer engineMesh;
        private GameObject mainCamera;
        [SerializeField] LayerMask lense;
        RaycastHit hit;

        private Vector3[] offset;
        private Vector3[] vertex;
        private float MaxDistance = 20f;

        public enum BlendMode { Opaque = 0, Cutout, Fade, Transparent }
        public static void changeRenderMode(Material standardShaderMaterial, BlendMode blendMode) { switch (blendMode) { case BlendMode.Opaque: standardShaderMaterial.SetFloat("_Mode", 0.0f); standardShaderMaterial.SetOverrideTag("RenderType", "Opaque"); standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One); standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero); standardShaderMaterial.SetInt("_ZWrite", 1); standardShaderMaterial.DisableKeyword("_ALPHATEST_ON"); standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON"); standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON"); standardShaderMaterial.renderQueue = -1; break; case BlendMode.Cutout: standardShaderMaterial.SetFloat("_Mode", 1.0f); standardShaderMaterial.SetOverrideTag("RenderType", "Opaque"); standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One); standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero); standardShaderMaterial.SetInt("_ZWrite", 1); standardShaderMaterial.EnableKeyword("_ALPHATEST_ON"); standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON"); standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON"); standardShaderMaterial.renderQueue = 2450; break; case BlendMode.Fade: standardShaderMaterial.SetFloat("_Mode", 2.0f); standardShaderMaterial.SetOverrideTag("RenderType", "Transparent"); standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha); standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha); standardShaderMaterial.SetInt("_ZWrite", 0); standardShaderMaterial.DisableKeyword("_ALPHATEST_ON"); standardShaderMaterial.EnableKeyword("_ALPHABLEND_ON"); standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON"); standardShaderMaterial.renderQueue = 3000; break; case BlendMode.Transparent: standardShaderMaterial.SetFloat("_Mode", 3.0f); standardShaderMaterial.SetOverrideTag("RenderType", "Transparent"); standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One); standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha); standardShaderMaterial.SetInt("_ZWrite", 0); standardShaderMaterial.DisableKeyword("_ALPHATEST_ON"); standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON"); standardShaderMaterial.EnableKeyword("_ALPHAPREMULTIPLY_ON"); standardShaderMaterial.renderQueue = 3000; break; } }

        private bool defected = false ;

        private void Start()
        {
            engineMesh.material.SetColor("_Color", new Color(0, 0, 0, 0));

        }
        void Update()
        {
            if (HandleBehaviour.instance.gameObject.tag == "Handle")
            {
                vertex = GetColliderVertexPositions(rootParent);
                offset = GetOffsetPositions(vertex);

                if (checkHit(vertex[0], offset[0]) && checkHit(vertex[1], offset[1]) && checkHit(vertex[2], offset[2]) && checkHit(vertex[3], offset[3]) &&
                    checkHit(vertex[4], offset[4]) && checkHit(vertex[5], offset[5]) && checkHit(vertex[6], offset[6]) && checkHit(vertex[7], offset[7]))
                {
                    changeRenderMode(transform.parent.parent.GetComponent<MeshRenderer>().material, BlendMode.Transparent);

                    if (!defected)
                        engineMesh.material.SetColor("_Color", new Color(255, 255, 255, 1));
                    else
                        engineMesh.material.SetColor("_Color", new Color(0, 0, 0, 0));


                }
                else
                {
                    changeRenderMode(transform.parent.parent.GetComponent<MeshRenderer>().material, BlendMode.Opaque);
                    engineMesh.material.SetColor("_Color", new Color(0, 0, 0, 0));

                }
            }
            else
            {
                changeRenderMode(transform.parent.parent.GetComponent<MeshRenderer>().material, BlendMode.Opaque);
                engineMesh.material.SetColor("_Color", new Color(0, 0, 0, 0));

            }

        }

        private Vector3[] GetColliderVertexPositions(GameObject cobject)
        {
            var vertices = new Vector3[8];
            var thisMatrix = cobject.transform.localToWorldMatrix;
            var storedRotation = cobject.transform.rotation;
            cobject.transform.rotation = Quaternion.identity;

            var extents = cobject.GetComponent<Collider>().bounds.extents;
            vertices[0] = thisMatrix.MultiplyPoint3x4(extents);
            vertices[1] = thisMatrix.MultiplyPoint3x4(new Vector3(-extents.x, extents.y, extents.z));
            vertices[2] = thisMatrix.MultiplyPoint3x4(new Vector3(extents.x, extents.y, -extents.z));
            vertices[3] = thisMatrix.MultiplyPoint3x4(new Vector3(-extents.x, extents.y, -extents.z));
            vertices[4] = thisMatrix.MultiplyPoint3x4(new Vector3(extents.x, -extents.y, extents.z));
            vertices[5] = thisMatrix.MultiplyPoint3x4(new Vector3(-extents.x, -extents.y, extents.z));
            vertices[6] = thisMatrix.MultiplyPoint3x4(new Vector3(extents.x, -extents.y, -extents.z));
            vertices[7] = thisMatrix.MultiplyPoint3x4(-extents);

            cobject.transform.rotation = storedRotation;
            return vertices;
        }
        private Vector3[] GetOffsetPositions(Vector3[] vertices)
        {
            var offsets = new Vector3[8];
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
            var dir = mainCamera.transform.localRotation * Vector3.forward * -100;
            for (var i = 0; i < vertices.Length; i++)
            {
                offsets[i] = mainCamera.transform.position - vertices[i];
            }
            return offsets;
        }


        private bool checkHit(Vector3 pos, Vector3 offset)
        {
            return Physics.Raycast(pos, offset, MaxDistance, lense);
        }



        protected override void OnNormal()
        {
            defected = false;
        }

        protected override void OnDefect()
        {
            Debug.Log("X-ray");
            defected = true;
        }

    }
}