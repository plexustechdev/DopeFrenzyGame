using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DopeFrenzy
{
    public class Building : MonoBehaviour, IDamagable
    {
        [SerializeField] private float _health;
        [SerializeField] private List<Sprite> damagedBuilding;
        [SerializeField] private int ScorePerDamage;
        public float health { set { _health = value; } get { return _health; } }


        private float maxHealth;
        private int currentIdx;
        private bool isDestroyed;

        void Start()
        {
            maxHealth = _health;
        }

        public void Destroy()
        {
            isDestroyed = true;

            //SinglePlayer
            LevelManager.instance.AddDestructionCombos();
        }

        //Optimasi lagi

        public void TakeDamage(float damage, Character attacker)
        {
            _health -= damage;
            if (_health < maxHealth * 0.75f && _health > maxHealth * 0.5f)
            {
                GetComponent<SpriteRenderer>().sprite = damagedBuilding[1];
            }
            else if (_health < maxHealth * 0.5f && _health > maxHealth * 0.25f)
            {
                GetComponent<SpriteRenderer>().sprite = damagedBuilding[2];
            }
            else if (_health < maxHealth * 0.25f && _health > 0)
            {
                GetComponent<SpriteRenderer>().sprite = damagedBuilding[3];
            }
            else if (_health <= 0)
            {
                GetComponent<SpriteRenderer>().sprite = damagedBuilding[4];
                Destroy();
            }


            if (!isDestroyed)
            {
                LevelManager.instance.AddScore(attacker, ((int)(ScorePerDamage * damage)));
            }


        }
    }
}


