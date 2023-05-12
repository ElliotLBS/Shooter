using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class GameSetup : MonoBehaviour
{
    void Start() // n�r scriptet start kommer den att skapa en spelare
    {
        CreatePlayer();
    }

   void CreatePlayer() //Om man �r den f�rsta in i rummet �r man "MasterClient" som betyder att man �r player 1
    {
        if(PhotonNetwork.IsMasterClient)  // Om man �r MasterClient kommer spelet att instanitate en prefab av spelaren
        {
            PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Player1"), Vector3.zero, Quaternion.identity);
        }
        else // Om man inte �r MasterClient kommer spelet att instanitate en prefab av en annan spelare
        {
            PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Player2"), Vector3.zero, Quaternion.identity);
        }
    }
}
