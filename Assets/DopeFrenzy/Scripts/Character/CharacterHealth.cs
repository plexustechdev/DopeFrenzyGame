using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DopeFrenzy
{
    public class CharacterHealth : MonoBehaviour
    {
        [SerializeField] private float m_Health;
        [SerializeField] private float maxHealth;


        [HideInInspector] public bool isDead;
        public UnityEvent OnDead;

        private Animator anim;

        void Start()
        {
            transform.Find("root").TryGetComponent<Animator>(out anim);
        }




        public void RestoreHealth(float healthAmount)
        {
            if (m_Health < maxHealth)
            {
                m_Health += healthAmount;
            }

            if (m_Health > maxHealth)
            {
                m_Health = maxHealth;
            }

        }

        public void ReduceHealth(float damage, Vector2 damageDirection, Character attacker)
        {
            m_Health -= damage;
            CheckHealth(damageDirection, attacker);
        }
        public void Die(Vector2 damageDirection, Character attacker)
        {
            //SinglePlayer
            if (!isDead)
                LevelManager.instance.AddScore(attacker, 100);


            isDead = true;


            //ANIMATION    
            SetAnimationDead(damageDirection);
            anim.SetInteger("state", 3);



            OnDead?.Invoke();

        }

        private void CheckHealth(Vector2 damageDirection, Character attacker)
        {
            if (m_Health > 0)
                return;


            Die(damageDirection, attacker);
        }

        void SetAnimationDead(Vector2 damageDirection)
        {
            if (damageDirection == Vector2.right)
            {
                anim.SetInteger("attackerDirection", 1);
            }
            else if (damageDirection == Vector2.left)
            {
                anim.SetInteger("attackerDirection", 3);
            }
            else if (damageDirection == Vector2.up)
            {
                anim.SetInteger("attackerDirection", 0);
            }
            else if (damageDirection == Vector2.down)
            {
                anim.SetInteger("attackerDirection", 2);
            }
        }



    }
}


