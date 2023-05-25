using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class FloatingHealtbar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Camera camera;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

   [SerializeField] Target enemy;
    PhotonView view;

    void Start()
    {
        enemy = transform.parent.parent.gameObject.GetComponent<Target>();
        camera = FindObjectOfType<Camera>();
        view = GetComponentInParent<PhotonView>();
   

    }

        public void UpdateFixedHealtBar(int currentValue, int maxValue)
        {
        if (view == null)
        {
            view = GetComponentInParent<PhotonView>();
        }
        else
        {
            if (view.IsMine)
            {
                slider.value = currentValue / maxValue;
            }
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

        slider.value = enemy.currentHealth;
        transform.rotation = camera.transform.rotation;
        transform.position = target.position + offset;
       
    }
}
