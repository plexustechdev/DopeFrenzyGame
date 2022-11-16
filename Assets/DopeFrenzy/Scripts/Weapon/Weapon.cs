using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DopeFrenzy
{

    public abstract class Weapon : MonoBehaviour, IPickable
    {
        public WeaponType weaponType;

        public  abstract Transform firePoint { set; get; }
        protected abstract LayerMask layerMask { set; get; }


        public abstract void Fire(Character character);


        protected void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                //SECTION - Show E Button
                UIManager.instance.eBtnIndicator.transform.position = transform.position + new Vector3(0, 0.2f, 0);
                UIManager.instance.ShowEButton(true);

                //SECTION - Assign to Inventory Stash
                other.GetComponent<Character>().characterInventory.Stash = this.gameObject;
            }

        }

        protected void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag == "Player") {
                //SECTION - Hide E Button
                UIManager.instance.ShowEButton(false);


                //SECTION - Remove from Inventory Stash
                other.GetComponent<Character>().characterInventory.Stash = null;
            }
        }

        public enum WeaponType{ 
            Primary
            ,Secondary
        }
    }

}

