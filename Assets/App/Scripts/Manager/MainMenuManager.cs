using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [Header("Panel")]
    public GameObject titleScreen;
    public GameObject MainMenu;
    public GameObject ConnetToNetwork;
    public GameObject option;
    public GameObject CharacterSelect;
    public GameObject HowToPlay;
    public GameObject QuitGamePanel;
    public GameObject LeaderBoard;
    public GameObject Profile;

    // instance
    public static MainMenuManager instance;


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

        titleScreen.SetActive(true);
        MainMenu.SetActive(false);
        ConnetToNetwork.SetActive(false);
        option.SetActive(false);
        CharacterSelect.SetActive(false);
        HowToPlay.SetActive(false);
        Profile.SetActive(false);
        QuitGamePanel.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowLeaderBoard()
    {
        titleScreen.SetActive(false);
        MainMenu.SetActive(false);
        ConnetToNetwork.SetActive(false);
        option.SetActive(false);
        CharacterSelect.SetActive(false);
        HowToPlay.SetActive(false);
        QuitGamePanel.SetActive(false);
        Profile.SetActive(false);
        LeaderBoard.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
