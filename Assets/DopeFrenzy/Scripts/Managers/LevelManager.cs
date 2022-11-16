using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace DopeFrenzy
{
    public class LevelManager : MonoBehaviour
    {

        #region Public Field Declaration
        //Singleton Object
        public static LevelManager instance;
        //Delegate Function for Starting Game
        public delegate void GameStart();
        public delegate void Timer();
        public GameStart onStart;
        #endregion

        public GameState gameState;
        public CinemachineVirtualCamera Vcam;
        public List<GamePlayer> playerList = new List<GamePlayer>();
        [HideInInspector] public Character character;

        [SerializeField] private CharacterSpawnerBase spawner;
        [SerializeField] private float timeRemaining = 3;
        [SerializeField] private GameOption gameOption;
        [SerializeField] private int destructionCombos;
        [SerializeField] private int killCombos;
        [SerializeField] private float lastDestructionCombos;
        [SerializeField] private float lastKillCombos;


        bool isGameStarted = false;


        public enum GameState
        {
            Waiting,
            Starting,
            Ending
        }


        void Start()
        {
            instance = this;

            //SetCameraToFollow
            spawner.OnSpawned += OnCharacterSpawned;

            //INIT UIGAME
            InitUI();
        }

        void Update()
        {
            if (!isGameStarted)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                    UIManager.instance.UpdateCountdownScreen(timeRemaining.ToString("0"));
                }
                else
                {
                    StartGame();
                }
            }
            else if (gameState == GameState.Starting)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                    UIManager.instance.UpdateInGameTimer(timeRemaining);
                }
                else
                {
                    StopGame();
                }
            }

            if (lastDestructionCombos >= timeRemaining + 5)
            {
                UIManager.instance.ShowDestructionCombos(false);
            }
        }

        public void AddDestructionCombos()
        {
            if (lastDestructionCombos != 0)
            {

                if (lastDestructionCombos <= timeRemaining + 5)
                {
                    destructionCombos++;
                    lastDestructionCombos = timeRemaining;
                    UIManager.instance.UpdateDestructionUI(destructionCombos);
                }
                else
                {
                    destructionCombos = 0;
                    lastDestructionCombos = 0;
                    UIManager.instance.ShowDestructionCombos(false);
                }
            }
            else
            {
                destructionCombos++;
                lastDestructionCombos = timeRemaining;

                UIManager.instance.UpdateDestructionUI(destructionCombos);
            }
        }

        public void AddScore(Character character, int score)
        {
            for (int i = 0; i < playerList.Count; i++)
            {
                if (playerList[i].character == character)
                {
                    playerList[i].score += score;

                    //Update UI Score
                    UIManager.instance.UpdateScore(playerList[i].score);
                }
            }
        }

        public void AddPlayer(Character character)
        {
            GamePlayer player = new GamePlayer(character, "playerName"); //SEMENTARA;
            playerList.Add(player);
        }

        public IEnumerator TimerFor(float idx, Timer callback)
        {
            yield return new WaitForSeconds(idx);
            callback();
        }

        void OnCharacterSpawned(Character character)
        {
            SetCameraToFollow(character);
            AddPlayer(character);
        }


        void StartGame()
        {
            isGameStarted = true;
            gameState = GameState.Starting;
            onStart?.Invoke();

            UIManager.instance.ResetScreen();   //Hide UI
            timeRemaining = gameOption.GetGameDuration();

        }

        void StopGame()
        {
            gameState = GameState.Ending;
            for (int i = 0; i < playerList.Count; i++)
            {
                UIManager.instance.InitResultScreen(playerList[i].name, playerList[i].score.ToString("000000"));
            }

            UIManager.instance.ShowScreen("resultScreen");

        }


        void SetCameraToFollow(Character character)
        {
            Vcam.Follow = character.transform;
        }

        void InitUI()
        {
            UIManager.instance.backButton.onClick.AddListener(() =>
            {
                GameManager.instance.ChangeScene("MainMenu");
            });
        }



    }

}

