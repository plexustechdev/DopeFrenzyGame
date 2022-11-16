using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DopeFrenzy
{

    public class PowerBox : MonoBehaviour, IDamagable
    {
        private bool isDestroyed;
        private Animator anim;
        [SerializeField] private float m_Health;

        void Start()
        {
            anim = GetComponent<Animator>();
        }
        public void Destroy()
        {
            isDestroyed = true;
            anim.SetBool("isDestroyed", true);

            //SinglePlayer
            LevelManager.instance.AddDestructionCombos();
        }

        public void TakeDamage(float damage, Character damager)
        {
            m_Health -= damage;
            if (m_Health <= 0 && !isDestroyed)
            {

                Destroy();
                return;
            }


        }
    }

}