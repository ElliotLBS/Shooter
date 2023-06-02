using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangegameObject : MonoBehaviour
{
    public GameObject[] gameObjects;
    public int y;
    GameObject gameobject;
    public GameObject spherePrefab;
    // Start is called before the first frame update
    void Start()
    {
        y = 0;
      //  gameobject = GetComponent<GameObject>();
        //rend.enabled = true;
      //  rend.sharedMaterial = material[x];
    }

    // Update is called once per frame
    void Update()
    {
       //gameobject.gameObject = gameObjects[y];
        if (Input.GetKeyDown(KeyCode.E))
        {
         //  

            NextGameObject();
       

        }
    }
    public void NextGameObject()
    {
        Instantiate(spherePrefab, transform.position, transform.rotation);
        if (y < 3)
        {
            y++;
        }
        else
        {
            y = 0;

        }
    }
}
