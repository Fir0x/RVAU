using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventRelay : MonoBehaviourPun
{
    [SerializeField] private UnityEvent<int, bool> _testEvent;

    [PunRPC]
    public void RaiseTest(int value, bool remote)
    {
        _testEvent.Invoke(value, remote);
        if (!remote)
            photonView.RPC("RaiseTest", RpcTarget.Others, value, true);
    }
}
