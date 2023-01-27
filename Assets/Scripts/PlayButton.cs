using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayButton : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject NetworkManager;
    public void DoClick()
    {
        Debug.Log("HELLLOOOOO");
    }
}
