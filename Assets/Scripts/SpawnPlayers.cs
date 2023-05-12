using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{

    public GameObject playerPrefabs;

    float minX = -17;
    float maxX = 16;
    float minY = 1;
     float maxY = 1;
    float minZ = -17;
    float maxZ = 16;
    // Start is called before the first frame update
    void Start()
    {
        //H�r s�ger vi att n�r scriptet s�tts ig�ng kommer den instantiate prefaben av spelaren i en random "x,y,z" variabel
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
        PhotonNetwork.Instantiate(playerPrefabs.name, randomPosition, Quaternion.identity);
    }
}
