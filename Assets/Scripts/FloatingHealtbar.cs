using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class FloatingHealtbar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Camera camera2;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

   [SerializeField] Target enemy;
    PhotonView view;

    void Start()
    {
        enemy = transform.parent.parent.gameObject.GetComponent<Target>();
        camera2 = FindObjectOfType<Camera>();
        view = GetComponentInParent<PhotonView>();
   

    }
    [PunRPC]
        public void UpdateFixedHealtBar(int currentValue, int maxValue)
        {
        if (view == null)
        {
            view = GetComponentInParent<PhotonView>();
        }
        else
        {
                slider.value = currentValue / maxValue;
        }
        }
    [PunRPC]
    void Update()
    {
        if (enemy == null)
        {
            enemy = transform.parent.parent.gameObject.GetComponent<Target>();
        }
        if (slider == null)
        {
            slider = GetComponent<Slider>();
        }

        slider.value = enemy.currentHealth; //spelarens currenthealth, inte enemy...
        Debug.LogError("slider value set to " + enemy.currentHealth);

        //problemet är att enemy.currentHealth hela tiden uppdateras tillbaka till 100. Den ska stanna på det uppdaterade värdet
        //jag hittar dock ingenstans där den sätter värdet till 100... -Simon

        transform.rotation = camera2.transform.rotation;
        transform.position = target.position + offset;
       
    }
}
