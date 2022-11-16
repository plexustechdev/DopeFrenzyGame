namespace DopeFrenzy
{
    [System.Serializable]
    public class GamePlayer
    {
        public string name;
        public int score;
        public Character character;

        public GamePlayer(Character character, string name)
        {
            this.score = 0;
            this.name = name;
            this.character = character;
        }
    }
}


