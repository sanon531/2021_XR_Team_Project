using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MagnetBehaviour : MonoBehaviour
{
    private Vector3 initialLocalPosition;
    private Vector3 initialLocalRotation;
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
            gameObject.tag = "Something";
            transform.position = initialLocalPosition;
            transform.rotation = Quaternion.Euler(initialLocalRotation);
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.tag = "Magnet";
        }
    }

}
