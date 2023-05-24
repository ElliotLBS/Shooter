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

    Target enemy;
    PhotonView view;

    void Start()
    {
        enemy = transform.parent.parent.gameObject.GetComponent<Target>();
        camera = FindObjectOfType<Camera>();
        view = GetComponent<PhotonView>();
    }

        public void UpdateFixedHealtBar(int currentValue, int maxValue)
    {
        slider.value = currentValue / maxValue;
      
    }
    void Update()
    {
     
            slider.value = enemy.currentHealth;
        transform.rotation = camera.transform.rotation;
        transform.position = target.position + offset;
        
    }
}
