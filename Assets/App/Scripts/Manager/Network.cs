using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
public class Network : MonoBehaviourPunCallbacks
{
    public GameObject Connected;
    public static Network instance;
    
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        Connected.SetActive(false);
        if (!PhotonNetwork.IsConnected)
        {
            Debug.Log("Connecting...");
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected");
        Connected.SetActive(true);
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
        MainMenuManager.instance.MainMenu.SetActive(true);
        MainMenuManager.instance.ConnetToNetwork.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
