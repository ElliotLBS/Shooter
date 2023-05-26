using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EnemySpawner : MonoBehaviour
{
    float timer;
    public Transform[] enemys;
    PhotonView view;
    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (PhotonNetwork.IsMasterClient)  // Om man �r MasterClient kommer spelet att instanitate en prefab av spelaren
        {
            timer += Time.deltaTime;
            if (timer > 3) // Varje 3rd sekund s� kommer det instantiate en enemy prefab med random spawn point
            {
                int rng = Random.Range(0, enemys.Length);
                PhotonNetwork.Instantiate("MovingTrainingDummy", new Vector3(0, 1, Random.Range(-19, 19)), enemys[rng].transform.rotation);
                timer = 0;

            }
        }
        else
        {

        }


    }
}
