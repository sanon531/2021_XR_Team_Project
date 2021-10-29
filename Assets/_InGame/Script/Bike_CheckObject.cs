using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike_CheckObject : CheckObject
{
    // Start is called before the first frame update

    [SerializeField] BoxCollider _collider;
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField]
    Material _wrongMaterial; 

    [SerializeField] List<GameObject> _childList;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public override void InitializeObject()
    {
        switch (_objectStatus)
        {
            case ObjectStatus.Fine:
                break;
            case ObjectStatus.Defect_DifferentMat:
                CallDifferentMat();
                break;
            case ObjectStatus.Defect_PartsLoss:
                CallPartLoss();
                break;
            default:
                //정상 적인 경우 일단 블록을 전
                _objectStatus = ObjectStatus.Fine;
                break;
        }
    }

    public void CallDifferentMat()
    {
        List<int> _falsePlaceList = new List<int>();
        for (int i = 0; i < _childList.Count; i++)
            _falsePlaceList.Add(i);

        int _falsePlace1 = _falsePlaceList[Random.Range(0, _falsePlaceList.Count)];
        _falsePlaceList.Remove(_falsePlace1);
        int _falsePlace2 = _falsePlaceList[Random.Range(0, _falsePlaceList.Count)];
        _falsePlaceList.Remove(_falsePlace2);
        int _falsePlace3 = _falsePlaceList[Random.Range(0, _falsePlaceList.Count)];
        _falsePlaceList.Remove(_falsePlace3);
        GameObject _crackedTarget;
        _crackedTarget = _childList[_falsePlace1];
        _crackedTarget.GetComponent<MeshRenderer>().material = _wrongMaterial;
        _crackedTarget = _childList[_falsePlace2];
        _crackedTarget.GetComponent<MeshRenderer>().material = _wrongMaterial;
        _crackedTarget = _childList[_falsePlace3];
        _crackedTarget.GetComponent<MeshRenderer>().material = _wrongMaterial;


    }
    public void CallPartLoss()
    {
        GameObject deleteTarget;
        deleteTarget = _childList[Random.Range(0, _childList.Count)];
        _childList.Remove(deleteTarget);
        Destroy(deleteTarget);
        deleteTarget = _childList[Random.Range(0, _childList.Count)];
        _childList.Remove(deleteTarget);
        Destroy(deleteTarget);

    }
}
