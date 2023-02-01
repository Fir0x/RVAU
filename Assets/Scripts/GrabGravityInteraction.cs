using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabGravityInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.GetComponent<OVRGrabbable>().isGrabbed)
            transform.GetComponent<Rigidbody>().useGravity = true;
    }
}
