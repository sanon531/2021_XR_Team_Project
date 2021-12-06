using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MagnetBehaviour : MonoBehaviour
{
    private Vector3 initialLocalPosition;
    private Vector3 initialLocalRotation;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        initialLocalPosition = transform.localPosition;
        initialLocalRotation = transform.localRotation.eulerAngles;
        
    }
    void Update()
    {        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.position = initialLocalPosition;
            transform.rotation = Quaternion.Euler(initialLocalRotation);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<CheckObject>()) { //Null exception 방지용, 제거예정
            if (other.gameObject.GetComponent<CheckObject>()._objectStatus == ObjectStatus.Fine)
            {
                Vector3 offset = other.transform.position - transform.position;
                distance = offset.sqrMagnitude;
                if (distance < 0.5f)
                {
                    distance = 0.5f;
                }
                other.transform.position -= offset.normalized * Time.deltaTime / distance;
            }
        }
    }
}
