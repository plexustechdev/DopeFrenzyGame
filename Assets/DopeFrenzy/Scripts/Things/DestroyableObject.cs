using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DopeFrenzy
{
    [RequireComponent(typeof(Animator), typeof(Collider2D))]
    public class DestroyableObject : MonoBehaviour, IDamagable
    {
        [SerializeField] private float m_Health;
        [SerializeField] private string destroyedParameter = "isDestroyed";
        [SerializeField] private int scorePerDamage;
        
        private bool isDestroyed;
        private Animator anim;

        void Start(){
            anim = GetComponent<Animator>();
        }

        public void Destroy(){
            isDestroyed = true;
            anim.SetBool(destroyedParameter, true);

            //SinglePlayer
            LevelManager.instance.AddDestructionCombos();
        }

        public void TakeDamage(float damage, Character attacker){
            m_Health -= damage;
            if(m_Health <= 0 && !isDestroyed){
                Destroy();
            }

            LevelManager.instance.AddScore(attacker, ((int)(damage * scorePerDamage)));
        }
    }

}

