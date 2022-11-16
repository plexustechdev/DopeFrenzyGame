using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DopeFrenzy
{
    [CreateAssetMenu]

    public class NumberListCombos : ScriptableObject
    {
        public List<Sprite> sprites;

        public Sprite GetSprite(char number)
        {
            for (int i = 0; i < sprites.Count; i++)
            {
                if (sprites[i].name == number.ToString())
                {
                    return sprites[i];
                }
            }

            return null;
        }
    }

}
