using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarState : MonoBehaviour
{
    public bool isHeld;
    public float heldtime;
    // Start is called before the first frame update
    void Start()
    {
        isHeld = false;
        heldtime = 0.0f;
    }

    void Update() {
        if(isHeld) {
            heldtime = heldtime + Time.deltaTime;
        } else {
            heldtime = 0.0f;
        }
    }

    public void ObjectHeld() {
        isHeld = true;
    }

    public void ObjectLetGo() {
        isHeld = false;
    }
}
