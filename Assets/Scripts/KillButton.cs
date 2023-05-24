using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillButton : MonoBehaviour
{
    public bool ButtonDown = false;

    public  void OnMouseDown()
    {
        ButtonDown = true;
        DestroyAll(tag);



    }
    public void Update()
    {
    //    Debug.LogError("Pressed Button");
      
    }

    public void ButtonPressed()
    {
        // Debug.LogError("Destryoed");
        while (GameObject.FindWithTag("Enemy") != null) Destroy(GameObject.FindWithTag("Enemy"));
        ButtonDown = false;

    
    }
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


