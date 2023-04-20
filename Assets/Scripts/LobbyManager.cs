using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public int roomSize;

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
        print("Trying to join");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        print("Can't Find Room");
        CreateRoom();
    }

    void CreateRoom()
    {
        print("Creating Room");
        int randomRoomNumber = Random.Range(0, 100000);
        print(randomRoomNumber);



        RoomOptions options = new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
              MaxPlayers = (byte)roomSize
        };
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, options);


    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        CreateRoom();
    }
    public void Cancel()
    {
        PhotonNetwork.LeaveRoom();
    }
}

