using UnityEngine;

namespace _TestObject
{
    /// <summary>
    /// 테스트 오브젝트의 기능, 새 기능 추가하고싶으면 이거 상속해서 쓰면 됨
    /// </summary>
    public abstract class TestObjectFeature : MonoBehaviour
    {
        [ReadOnly,SerializeField] private bool isDefect = false;
        public bool IsDefect => isDefect;

        public void SetDefect(bool defect)
        {
            isDefect = defect;
            if(defect) 
                OnDefect();
            else
                OnNormal();
        }

        protected virtual void OnNormal()
        {
        }

        protected virtual void OnDefect()
        {
        }
    }
}