
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hardcode_LoadSceneClick : MonoBehaviour
{

    public string TargetScene = "ConnectToNetwork";
    public Button TargetButton;

    public void LoadScene()
    {
        //Melakukan perpindahan antar scene. Catatan: Scene yang dipanggil sudah didaftarkan di Build Setting
        SceneManager.LoadScene(TargetScene);
    }

    // Start is called before the first frame update
    void Start()
    {
        TargetButton = GetComponent<Button>();
        TargetButton.onClick.AddListener(LoadScene);
    }


}

