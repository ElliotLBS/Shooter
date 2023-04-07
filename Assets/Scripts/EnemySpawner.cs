using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float timer;
    public Transform[] enemys;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3)
        {
            int rng = Random.Range(0, enemys.Length);
            Instantiate(enemys[rng], new Vector3(0, 1, Random.Range(-19, 19)), enemys[rng].transform.rotation);
            timer = 0;
        }
    }
}
