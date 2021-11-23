using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catalog_Script : MonoBehaviour
{
    private Vector3 initialLocalPosition;
    private Vector3 initialLocalRotation;

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
}
