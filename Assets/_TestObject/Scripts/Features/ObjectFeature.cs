using UnityEngine;

namespace _TestObject
{
    /// <summary>
    ///normal일시 correct object가 defect일시 wrong object가 켜짐 
    /// </summary>
    public class ObjectFeature : TestObjectFeature
    {
        [SerializeField] private GameObject correctObject;
        [SerializeField] private GameObject wrongObject;
        protected override void OnNormal()
        {
            if(correctObject != null)
                correctObject.SetActive(true);
            if(wrongObject != null)
                wrongObject.SetActive(false);
        }
        protected override void OnDefect()
        {
            if(correctObject != null)
                correctObject.SetActive(false);
            if(wrongObject != null)
                wrongObject.SetActive(true);
        }
    }
}