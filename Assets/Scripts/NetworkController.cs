using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class NetworkController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    Button startButton;
    [SerializeField]
    InputField nameField;

    void Start() // N�r scripet startar kommer den hitta alla settings s� spelet har
    {
        startButton.interactable = false;
        PhotonNetwork.ConnectUsingSettings();
        print("Connecting...");
    }

    public override void OnConnectedToMaster() // N�r den �r klar, kommer den connecta till spelaren och vart personers region �r, f�r att sedan g�ra s� att spelaren kan anv�nda knappen
    {
        print("Connect to server in" + PhotonNetwork.CloudRegion);
        startButton.interactable = true;
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void SetUserName() // H�r kommer spelaren kunna skriva in sitt namn som kan anv�ndas som namn ni spelet
    {
        PhotonNetwork.LocalPlayer.NickName = nameField.text;
    }
}
