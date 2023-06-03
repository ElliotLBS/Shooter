using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{

    public Material[] material;
    public int x;
    Renderer rend;
    Texture texture;
    // Start is called before the first frame update 
    void Start()
    {
        x = 0;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[x];
    }

    // Update is called once per frame
    void Update()
    {
        rend.sharedMaterial = material[x];
        if (Input.GetKeyDown(KeyCode.E))
        {
            NextColor();
        }
    }

    public void NextColor()
    {
        if(x<3)
        {
            x++;
        }
        else
        {
            x = 0;

        }
    }
}
