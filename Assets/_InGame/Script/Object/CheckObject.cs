using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectStatus
{
    //���� ����
    Fine,
    
    // ��ǰ�� ����� ����
    Defect_PartsLoss,
    
    // ���͸��� ������ �������� ������ ����.
    Defect_DifferentMat,
    
    //���� �Ҹ��� ��
    Defect_InnerCrush,

    //�������� �ӵ��� ��û �����ų� ����
    Defect_Weight,

    // �ֺ��� �ڼ� ������Ʈ�� ������ ������.
    Defect_Magent
}

public class CheckObject : MonoBehaviour
{
    public ObjectStatus _objectStatus = ObjectStatus.Fine;

    public virtual void InitializeObject()
    {
    }
}
