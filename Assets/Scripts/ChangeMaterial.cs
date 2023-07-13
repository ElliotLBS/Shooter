using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{

    public Texture[] textures;
    public int x;
    Renderer rend;
    Texture texture;
    // Start is called before the first frame update 
    void Start()
    {
        x = 0;
        rend = GetComponent<Renderer>();
        texture = GetComponent<Texture>();
        rend.enabled = true;
        rend.material.mainTexture = textures[x];
    }

    // Update is called once per frame
    void Update()
    {
        rend.material.mainTexture = textures[x];
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
