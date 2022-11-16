using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DopeFrenzy
{
    public interface IDamagable
    {
        public void Destroy();

        public void TakeDamage(float damage, Character attacker);
    }

}
