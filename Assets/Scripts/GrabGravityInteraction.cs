using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabGravityInteraction : MonoBehaviour
{
    private OVRGrabbable _grabbable;
    private Rigidbody _rb;

    private void Awake()
    {
        _grabbable = GetComponent<OVRGrabbable>();
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_grabbable != null && _grabbable.isGrabbed)
            _rb.useGravity = true;
    }
}
