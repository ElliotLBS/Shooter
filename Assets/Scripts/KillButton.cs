using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class KillButton : MonoBehaviour
{
    public bool ButtonDown = false;

    public  void OnMouseDown()
    {
        ButtonDown = true;
        DestroyAll(tag);
    }
    [PunRPC]
    public void DestroyAll(string tag)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            GameObject.Destroy(enemies[i]);
        }
        ButtonDown = false;
    }



}


