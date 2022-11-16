using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace DopeFrenzy
{
    public class MenuGUIManager : MonoBehaviour
    {
        public static MenuGUIManager instance;

        public List<Screen> screens;

        [Header("Main Menu")]
        public List<Sprite> howtoPlaySprite;
        public GameObject howToPlaySection;



        void Start()
        {
            instance = this;
            

            StartCoroutine(Splash()); //FIXME sementara. 
        }

        IEnumerator Splash()
        {
            OpenScreen("splashScreen");
            yield return new WaitForSeconds(3);
            OpenScreen("mainMenuScreen");
        }

        public void OpenScreen(string screenName)
        {

            ResetScreen();

            for (int i = 0; i < screens.Count; i++)
            {
                if (screens[i].screenName == screenName)
                {
                    screens[i].Show();
                }
            }
        }

        void ResetScreen()
        {
            for (int i = 0; i < screens.Count; i++)
            {
                screens[i].Hide();
            }
        }
        
        /// <summary>
        /// Call in Unity Event Button.
        /// </summary>
        public void OpenHowToPlay()
        {
            howToPlaySection.SetActive(true);
        }

        public void NextHowToPlay()
        {
            if (howToPlaySection.transform.GetChild(1).GetComponent<Image>().sprite != howtoPlaySprite[1])
            {
                howToPlaySection.transform.GetChild(1).GetComponent<Image>().sprite = howtoPlaySprite[1];
            }
            else
            {
                howToPlaySection.SetActive(false);
                howToPlaySection.transform.GetChild(1).GetComponent<Image>().sprite = howtoPlaySprite[0];
            }
        }




    }

}

