using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class GameSetup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CreatePlayer();
    }

   void CreatePlayer()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Player1"), Vector3.zero, Quaternion.identity);
        }
        else
        {
            PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Player2"), Vector3.zero, Quaternion.identity);
        }
    }
}
