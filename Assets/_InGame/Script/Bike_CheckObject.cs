using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike_CheckObject : CheckObject
{
    // Start is called before the first frame update

    [SerializeField] BoxCollider _collider;
    [SerializeField] Rigidbody _rigidbody;

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
            case ObjectStatus.Defect_Cracked:
                CallCracked();
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

    private void OnCollisionEnter(Collision collision)
    {
    }
    private void OnCollisionExit(Collision collision)
    {

    }


    public void CallCracked()
    {

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
