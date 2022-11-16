using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace DopeFrenzy
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;
        [Header("Screens")]
        public List<Screen> screenList = new List<Screen>();

        [Header("Countdown Screen")]
        [SerializeField] private GameObject countdownScreen;
        public TMP_Text countdownTxt;

        [Header("Result Screen")]
        [SerializeField] private GameObject resultScreen;
        [SerializeField] private GameObject playerScorePrefab;
        public Button backButton;


        [Header("InGame UI")]
        public TMP_Text timer;
        public TMP_Text score;

        public Image weaponImg;

        [Header("Combos UI")]
        public Transform spawnNumber;
        public GameObject numberPrefab;
        public GameObject destructionUI;

        [Header("Interactivity")]
        public GameObject eBtnIndicator;

        [Header("References")]
        public NumberListCombos listSpriteNumber;



        void Awake()
        {
            instance = this;
        }

        void Start()
        {
            ShowScreen("countdownScreen");
        }

        public void UpdateCountdownScreen(string txt)
        {
            countdownTxt.text = txt;
        }

        public void UpdateDestructionUI(int i)
        {
            ResetDestructionUICombos();

            string numb = i.ToString();
            for (int j = 0; j < numb.Length; j++)
            {
                Sprite img = listSpriteNumber.GetSprite(numb[j]);
                Image image = Instantiate(numberPrefab, spawnNumber.transform).GetComponent<Image>();
                image.sprite = img;
            }

            spawnNumber.GetComponent<RectTransform>().sizeDelta = new Vector2(100 * numb.Length, 100);
            ShowDestructionCombos(true);
        }


        public void ResetDestructionUICombos()
        {
            for (int i = 0; i < spawnNumber.childCount; i++)
            {
                Destroy(spawnNumber.GetChild(i).gameObject);
            }
        }

        public void ShowDestructionCombos(bool val)
        {
            destructionUI.SetActive(val);
        }

        public void UpdateInGameTimer(float currentTime)
        {
            currentTime += 1;

            float minute = Mathf.FloorToInt(currentTime / 60);
            float second = Mathf.FloorToInt(currentTime % 60);

            timer.text = string.Format("{0:00}:{1:00}", minute, second);
        }

        public void InitResultScreen(string name, string score)
        {
            GameObject go = Instantiate(playerScorePrefab, resultScreen.transform.Find("playersScore"));
            go.transform.Find("name").GetComponent<TMP_Text>().text = name;
            go.transform.Find("score").GetComponent<TMP_Text>().text = score;
        }

        public void UpdateScore(int score)
        {
            this.score.text = score.ToString("000000");
        }

        public void UpdateWeapon(Sprite weaponSprite) {
            DOTween.Kill(weaponImg.GetComponent<RectTransform>());
            weaponImg.GetComponent<RectTransform>().DOLocalMoveY(-50,0.2f)
                .OnComplete(()=>            
                weaponImg.GetComponent<RectTransform>().DOLocalMoveY(50, 0)
                    .OnStart(()=>
                      weaponImg.sprite = weaponSprite
                    )
                    .OnComplete(()=>
                     weaponImg.GetComponent<RectTransform>().DOLocalMoveY(0, 0.2f)
                    )
                );
        }

        public void ShowScreen(string screenName)
        {
            ResetScreen();
            screenList.ForEach(screen =>
            {
                if (screenName == screen.screenName)
                {
                    screen.Show();
                }
            });
        }


        public void ResetScreen()
        {
            screenList.ForEach(screen =>
            {
                screen.Hide();
            });
        }

        #region  E Interactive Button
        public void ShowEButton(bool val)
        {
            eBtnIndicator.SetActive(val);
        }
        #endregion


    }
}


