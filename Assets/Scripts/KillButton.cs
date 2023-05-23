using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillButton : MonoBehaviour
{
    public bool ButtonDown = false;

    private void OnMouseDown()
    {
        ButtonDown = true;

   
    }
    public void Update()
    {
    //    Debug.LogError("Pressed Button");
        if (ButtonDown == true)
        {
            ButtonPressed();
        }
    }

    public void ButtonPressed()
    {
       // Debug.LogError("Destryoed");
      Destroy(GameObject.FindWithTag("Enemy"));
    }

}
