using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DopeFrenzy
{
    public class SingleCharacterSpawner : CharacterSpawnerBase
    {
        [SerializeField] Character m_Character;
        [SerializeField] bool SpawnCharacter = false;

        void Start()
        {

            if (SpawnCharacter)
                Spawn();
        }

        

        public override Character GetCharacter()
        {
            return m_Character;
        }

        public override Vector3 GetSpawnPoint()
        {
            return new Vector3(0, 0, -8);
        }


    }
}


