using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehopPlatforms : MonoBehaviour
{

    public float standingtimer = 3f;
    public bool Standing = false;

    [SerializeField]
    Transform destination;

    public PlayerScript playerscript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
  /*  public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Player"))
        {
            print("standingon");
            Standing = true;
        }
        else
        {
            Standing = false;
            print("notstanding");
            standingtimer = 3f;
        }
    }*/


}
