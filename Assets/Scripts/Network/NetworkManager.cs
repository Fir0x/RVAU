using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Keep the object alive
        DontDestroyOnLoad(gameObject);

        // Setup Photon connection
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;

    }
/*
    public void ConnectToNetwork()
    {
        if (!m_connected)
        {
            m_connected = true;

            networkStatus.Invoke("Connecting...");

            RoomOptions roomOptions = new RoomOptions();
            roomOptions.IsVisible = false;
            roomOptions.MaxPlayers = 2;
            PhotonNetwork.JoinOrCreateRoom("Room 237", roomOptions, TypedLobby.Default);

            networkStatus.Invoke("Waiting for other player...");
        }
    }

    override public void OnPlayerEnteredRoom(Player otherPlayer)
    {
        m_playerCount++;

        networkStatus.Invoke("" + m_playerCount);

        if (PhotonNetwork.IsMasterClient && m_playerCount == 1)
        {
            PhotonNetwork.LoadLevel(1);
        }
    }*/
}
