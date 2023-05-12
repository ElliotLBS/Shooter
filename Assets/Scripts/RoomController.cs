using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class RoomController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    int sceneIndex;
     
    public override void OnEnable() //Här ser vi att vi overridadar denna photon class void OnEnable() så detta gör att den connectar till spelaren

    {
        PhotonNetwork.AddCallbackTarget(this);
    }
    public override void OnDisable()//Här ser vi att vi overridadar denna photon class void OnDisable() så detta gör att den  inte connectar till spelaren

    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }
    public override void OnJoinedRoom() // Om den hittar ett rum för spelaren så kommer den starta spelet
    {
        StartGame();
    }
    void StartGame() // Om StartGame() är på kommer den ta den spelare som har connectat och sätta in i en scene 
    {
        if(PhotonNetwork.IsMasterClient)
        {
            print("Starting Game");
            PhotonNetwork.LoadLevel(sceneIndex);

        }
    }

}
