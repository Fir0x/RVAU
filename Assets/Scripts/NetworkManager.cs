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

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsVisible = false;
        roomOptions.MaxPlayers = 2;

        PhotonNetwork.JoinOrCreateRoom("Game", roomOptions, TypedLobby.Default);
    }

    public override void OnPlayerEnteredRoom(Player otherPlayer)
    {
        Debug.Log("Other player entered Room");
        PhotonNetwork.LoadLevel(2);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Failed to join room: " + message);
    }
}
