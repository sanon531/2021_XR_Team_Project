using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingObjectNoticer : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CheckObject>()._objectStatus == ObjectStatus.Fine)
        {
            //FXPlayer.PlayFX();
            Destroy(collision.gameObject);
        }
        else
        {
            Debug.Log("Wrong!!");
        }

    }
}
