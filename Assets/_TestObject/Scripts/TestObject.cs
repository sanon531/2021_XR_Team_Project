using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _TestObject
{
    /// <summary>
    /// 엔티티
    /// </summary>
    public class TestObject : MonoBehaviour
    {
        [Header("<Debug>")] [SerializeField] private bool useDebug;
        [SerializeField] private List<TestObjectFeature> debug_defectFeatures;

        [Header("<Test Object>")] [SerializeField, ReadOnly]
        private bool isCorrectObject;

        public bool IsCorrectObject => isCorrectObject;

        private void Start()
        {
            if (useDebug) Initialize(debug_defectFeatures);
        }
        
        public void Initialize(bool hasError)
        {
            isCorrectObject = !hasError;
            var features = GetComponentsInChildren<TestObjectFeature>();

            if (hasError)
            {
                var defect = Random.Range(0, features.Length);
                for (var i = 0; i < features.Length; i++)
                {
                    features[i].SetDefect(i == defect);
                }
            }
            else
            {
                foreach (var feature in features)
                {
                    feature.SetDefect(false);
                }
            }
        }
        
        public void Initialize(List<TestObjectFeature> defectFeatures)
        {
            isCorrectObject = defectFeatures.Count <= 0;
            var features = GetComponentsInChildren<TestObjectFeature>();
            for (var i = 0; i < features.Length; i++)
            {
                if (defectFeatures.Contains(features[i]))
                {
                    features[i].SetDefect(true);
                    isCorrectObject = false;
                }
                else
                {
                    features[i].SetDefect(false);
                }
            }
        }
    }
}