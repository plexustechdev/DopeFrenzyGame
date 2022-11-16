using UnityEngine;

namespace DopeFrenzy
{
    [CreateAssetMenu]
    public class GameOption : ScriptableObject
    {
        [Tooltip("How long the game will be in minute")]
        [SerializeField] private int gameDuration;
        [SerializeField] private int maxPlayer;

        public int GetGameDuration(){
            return gameDuration * 60;
        }

    }

}

