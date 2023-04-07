using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip enemyDeathSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        enemyDeathSound = Resources.Load<AudioClip>("EnemyDeath");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void PlaySound(string clip)
    {

        switch (clip)
        {
            case "EnemyDeath":
                audioSrc.PlayOneShot(enemyDeathSound);
                break;
        }
    }
}
