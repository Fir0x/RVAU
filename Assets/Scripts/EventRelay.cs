using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventRelay : MonoBehaviourPun
{
    private static EventRelay _instance;

    [SerializeField] private UnityEvent<int> _onBuyRessource;
    [SerializeField] private UnityEvent<Guid> _onSellPotion;

    private void Awake()
    {
        _instance = this;
    }

    public static EventRelay Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("No instance of event relay");

            return _instance;
        }
    }

    [PunRPC]
    public void RaiseBuyRessource(int ressourceIndex, bool isLocal)
    {
        _onBuyRessource.Invoke(ressourceIndex);
        if (isLocal)
            photonView.RPC("RaiseBuyRessource", RpcTarget.Others, ressourceIndex, false);
    }

    [PunRPC]
    public void RaiseSellPotion(Guid potionGuid, bool isLocal)
    {
        _onSellPotion.Invoke(potionGuid);
        if (isLocal)
            photonView.RPC("RaiseSellPotion", RpcTarget.Others, potionGuid, false);
    }
}
