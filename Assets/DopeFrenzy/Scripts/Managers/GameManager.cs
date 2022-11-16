using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace DopeFrenzy
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager instance;
        
        void Awake(){
            if(instance == null){
                instance = this;
            }
            Application.targetFrameRate = 60;
            DontDestroyOnLoad(this);
        }

        public void Play(){
            SceneManager.LoadScene("Gameplay");
        }

        public void ChangeScene(string sceneName){
            SceneManager.LoadScene(sceneName);
        }

    }
}


