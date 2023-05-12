using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public int roomSize;

    public void JoinRoom() // Här kommer den joina ett spel som redans finns
    {
        PhotonNetwork.JoinRandomRoom();
        print("Trying to join");
    }

    public override void OnJoinRandomFailed(short returnCode, string message) // Om det inte finns ett rum kommer spelaren att skapa ett själv automatiskt
    {
        print("Can't Find Room");
        CreateRoom();
    }

    void CreateRoom() //Rummet som skapas kommer kunna ha ett nummer mellan 0 - 100000, som serverip's
    {
        print("Creating Room");
        int randomRoomNumber = Random.Range(0, 100000);
        print(randomRoomNumber);



        RoomOptions options = new RoomOptions() // Om ett rum har skapats så kommer den följa rum reglerna, som kan ses av players efter att en server finns
        {
            IsVisible = true,
            IsOpen = true,
              MaxPlayers = (byte)roomSize
        };
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, options);


    }
    public override void OnCreateRoomFailed(short returnCode, string message) // Om det inte gick att skapa ett rum kommer spelaren kunna skapa ett eget rum automatiskt
    {
        CreateRoom();
    }
    public void Cancel() // Om man trycker på "cancel" eller något händer som gör att man rummet inte behövs, kommer alla i serverna lämna rummet
    {
        PhotonNetwork.LeaveRoom();
    }
}

