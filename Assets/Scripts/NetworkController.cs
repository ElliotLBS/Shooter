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

    void Start() // När scripet startar kommer den hitta alla settings så spelet har
    {
        startButton.interactable = false;
        PhotonNetwork.ConnectUsingSettings();
        print("Connecting...");
    }

    public override void OnConnectedToMaster() // När den är klar, kommer den connecta till spelaren och vart personers region är, för att sedan göra så att spelaren kan använda knappen
    {
        print("Connect to server in" + PhotonNetwork.CloudRegion);
        startButton.interactable = true;
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void SetUserName() // Här kommer spelaren kunna skriva in sitt namn som kan användas som namn ni spelet
    {
        PhotonNetwork.LocalPlayer.NickName = nameField.text;
    }
}
