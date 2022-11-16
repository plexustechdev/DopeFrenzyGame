using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DopeFrenzy
{
    public class Vehicle : MonoBehaviour, IDamagable
    {
        private float m_health;
        public float health{set{m_health = value;} get{return m_health;}}

        public virtual void Destroy(){

        }

        public virtual void TakeDamage(float damage, Character attacker){

        }
    }
}


