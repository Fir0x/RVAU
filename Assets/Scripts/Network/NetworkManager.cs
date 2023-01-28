using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    private bool _isInRoom;

    // Start is called before the first frame update
    void Start()
    {
        // Keep the object alive
        DontDestroyOnLoad(gameObject);

        // Setup Photon connection
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;

        _isInRoom = false;
        Debug.Log("HO HI MARK");
    }

    public void ConnectToNetwork()
    {
        Debug.Log("CLICK CLICK\n");
        if (!_isInRoom)
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.IsVisible = false;
            roomOptions.MaxPlayers = 2;

            PhotonNetwork.JoinOrCreateRoom("Game", roomOptions, TypedLobby.Default);
            Debug.Log("I joined a room!\n");
            _isInRoom = true;
        }
    }

    override public void OnPlayerEnteredRoom(Player otherPlayer)
    {
/*        m_playerCount++;

        networkStatus.Invoke("" + m_playerCount);

        if (PhotonNetwork.IsMasterClient && m_playerCount == 1)
        {
            PhotonNetwork.LoadLevel(1);
        }*/
    }
}
