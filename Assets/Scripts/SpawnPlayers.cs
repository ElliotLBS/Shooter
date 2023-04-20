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
        
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
        PhotonNetwork.Instantiate(playerPrefabs.name, randomPosition, Quaternion.identity);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
