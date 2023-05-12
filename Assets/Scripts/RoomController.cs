using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class RoomController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    int sceneIndex;
     
    public override void OnEnable() //H�r ser vi att vi overridadar denna photon class void OnEnable() s� detta g�r att den connectar till spelaren

    {
        PhotonNetwork.AddCallbackTarget(this);
    }
    public override void OnDisable()//H�r ser vi att vi overridadar denna photon class void OnDisable() s� detta g�r att den  inte connectar till spelaren

    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }
    public override void OnJoinedRoom() // Om den hittar ett rum f�r spelaren s� kommer den starta spelet
    {
        StartGame();
    }
    void StartGame() // Om StartGame() �r p� kommer den ta den spelare som har connectat och s�tta in i en scene 
    {
        if(PhotonNetwork.IsMasterClient)
        {
            print("Starting Game");
            PhotonNetwork.LoadLevel(sceneIndex);

        }
    }

}
