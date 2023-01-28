using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventChanneler : MonoBehaviourPun
{
    [SerializeField] private UnityEvent _testEvent;

    [PunRPC]
    void RaiseTest()
    {
        _testEvent.Invoke();
    }
}
