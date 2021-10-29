using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectStatus
{
    //정상 상태
    Fine,
    
    // 부품의 몇가지가 빠짐
    Defect_PartsLoss,
    
    // 매터리얼 수정된 버전으로 긁힌게 보임.
    Defect_DifferentMat,
    
    //흔들면 소리가 남
    Defect_InnerCrush,

    //떨어지는 속도가 엄청 느리거나 빠름
    Defect_Weight,

    // 주변의 자석 오브젝트가 있으면 부착됨.
    Defect_Magent
}

public class CheckObject : MonoBehaviour
{
    public ObjectStatus _objectStatus = ObjectStatus.Fine;

    public virtual void InitializeObject()
    {
    }
}
