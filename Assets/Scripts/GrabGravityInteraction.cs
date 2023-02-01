using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GrabGravityInteraction : MonoBehaviour
{
    public delegate void GrabGravityInteractionDelegate();

    private OVRGrabbable _grabbable;
    private Rigidbody _rb;
    private event GrabGravityInteractionDelegate _grabbed;

    private void Awake()
    {
        _grabbable = GetComponent<OVRGrabbable>();
        _rb = GetComponent<Rigidbody>();
    }

    public void Subscribe(GrabGravityInteractionDelegate sub)
    {
        _grabbed += sub;
    }

    public void Unsubscribe(GrabGravityInteractionDelegate sub)
    {
        _grabbed -= sub;
    }

    // Update is called once per frame
    void Update()
    {
        if (_grabbable != null && _grabbable.isGrabbed)
        {
            _rb.useGravity = true;
            _grabbed.Invoke();
        }
    }
}
