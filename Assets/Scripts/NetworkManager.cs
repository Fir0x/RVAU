using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        // Keep the object alive
        DontDestroyOnLoad(gameObject);

        // Setup Photon connection
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;

        Debug.Log("START NM!");
    }

    override public void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsVisible = false;
        roomOptions.MaxPlayers = 2;

        PhotonNetwork.JoinOrCreateRoom("Game", roomOptions, TypedLobby.Default);
    }

    override public void OnPlayerEnteredRoom(Player otherPlayer)
    {
        Debug.Log("Other player entered Room");
        PhotonNetwork.LoadLevel(2);
    }
}
