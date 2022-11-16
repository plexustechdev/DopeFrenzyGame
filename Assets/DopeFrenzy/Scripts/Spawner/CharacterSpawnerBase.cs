using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DopeFrenzy
{
    public abstract class CharacterSpawnerBase : MonoBehaviour
    {
        public delegate void SpawnCallback(Character character);


        public abstract Character GetCharacter();
        public abstract Vector3 GetSpawnPoint();
        public SpawnCallback OnSpawned;
        public virtual void Spawn()
        {
            Character character = Instantiate(GetCharacter(), GetSpawnPoint(), Quaternion.identity);
            OnSpawned?.Invoke(character);
        }
    }

}

