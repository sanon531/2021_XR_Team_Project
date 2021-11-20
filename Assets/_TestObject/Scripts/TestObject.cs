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
        [Header("<Debug>")] 
        [SerializeField] private bool useDebug;
        [SerializeField] private List<TestObjectFeature> debug_defectFeatures;
        
        [Header("<Test Object>")] 
        [SerializeField,ReadOnly] private bool isCorrectObject;
        
        public bool IsCorrectObject => isCorrectObject;
        private void Start()
        {
            if(useDebug) SetDefect(debug_defectFeatures);
        }

        /// <summary>
        /// defect 개수를 입력,  error 개수만큼 랜덤 기능이 defect
        /// 0개면 correct object
        /// </summary>
        public void SetDefect(int error)
        {
            isCorrectObject = error <= 0;
            var features = GetComponentsInChildren<TestObjectFeature>();
            var defect = GetRandomDefect(features.Length, error);
            for (var i = 0; i < features.Length; i++)
            {
                features[i].SetDefect(defect[i]);
            }
        }

        /// <summary>
        /// defect 기능을 입력 correct object
        /// </summary>
        public void SetDefect(List<TestObjectFeature> defectFeatures)
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

        /// <summary>
        /// 랜덤으로 pick 개수만큼 true로 설정
        /// </summary>
        private bool[] GetRandomDefect(int count,int pick)
        {
            var arr = new int[count];
            var ret = new bool[count];
            //초기화
            for (var i = 0; i < count; i++)
            {
                arr[i] = i;
                ret[i] = false;
            }
            //셔플
            for (var i = 0; i < pick; i++)
            {
                var rand = Random.Range(i, pick);
                ret[arr[rand]] = true;
                arr[rand] = arr[i];
            }
            return ret;
        }
    }

}
