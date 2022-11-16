using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DopeFrenzy
{
    public class VendingMachine : MonoBehaviour, IDamagable
    {
        [SerializeField] private List<Sprite> damagedSprite;
        [SerializeField] private int ScorePerDamage;

        public float health
        {
            set
            {
                m_Health = value;
            }

            get
            {
                return m_Health;
            }
        }

        private float m_Health;
        private bool isDestroyed;
        private int currentIdx = 0;
        private Animator animator;



        void Awake()
        {
            animator = GetComponent<Animator>();
        }


        public void Destroy()
        {
            isDestroyed = true;
            animator.SetBool("isDestroyed", true);
            LevelManager.instance.AddDestructionCombos();
        }

        public void TakeDamage(float damage, Character attacker)
        {
            currentIdx++;
            try
            {
                GetComponent<SpriteRenderer>().sprite = damagedSprite[currentIdx];
            }
            catch
            {
                if (!isDestroyed)
                    Destroy();
            }

            if (!isDestroyed)
            {
                LevelManager.instance.AddScore(attacker, ((int)(ScorePerDamage * damage)));
            }


        }


    }



}


