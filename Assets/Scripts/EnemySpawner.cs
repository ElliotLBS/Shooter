using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EnemySpawner : MonoBehaviour
{
    float timer;
    public Transform[] enemys;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3) // Varje 3rd sekund så kommer det instantiate en enemy prefab med random spawn point
        {
            int rng = Random.Range(0, enemys.Length);
           PhotonNetwork.Instantiate("MovingTrainingDummy", new Vector3(0, 1, Random.Range(-19, 19)), enemys[rng].transform.rotation);
           timer = 0;
        }
     
    }
}
