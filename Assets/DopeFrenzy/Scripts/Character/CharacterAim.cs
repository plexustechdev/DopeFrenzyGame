using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DopeFrenzy
{
    public class CharacterAim : MonoBehaviour
    {
        private SpriteRenderer WeaponspriteRenderer;
        private EquipHandler equipHandler;


        void Start()
        {
            equipHandler = transform.Find("equip").GetComponent<EquipHandler>(); //NOTE "equip" is mandatory, listed on character prefab

            try
            {
                WeaponspriteRenderer = equipHandler.transform.GetChild(0).GetComponent<SpriteRenderer>();
                equipHandler.isEquiped = true;
            }
            catch (System.Exception)
            {

                equipHandler.isEquiped = false;
            }

        }

        void CheckWeaponSprite()
        {
            if (equipHandler.isEquiped)
            {
                WeaponspriteRenderer = equipHandler.transform.GetChild(0).GetComponent<SpriteRenderer>();
            }
            else
            {
                WeaponspriteRenderer = null;
            }
        }

        void FixedUpdate()
        {
            CheckWeaponSprite();
            var mousePosition = Camera.main.ScreenToWorldPoint(InputManager.instance.inputPlayer.Player.Aim.ReadValue<Vector2>());

            if (equipHandler.isEquiped)
            {



                Vector2 direction = new Vector2(
                    mousePosition.x - transform.position.x,
                    mousePosition.y - transform.position.y
                );




                equipHandler.transform.right = direction;
                if (mousePosition.x > equipHandler.transform.position.x)
                {
                    WeaponspriteRenderer.flipY = false;
                    equipHandler.equipedWeapon.firePoint.transform.localPosition = new Vector3(equipHandler.equipedWeapon.firePoint.transform.localPosition.x, Mathf.Abs(equipHandler.equipedWeapon.firePoint.transform.localPosition.y), equipHandler.equipedWeapon.firePoint.transform.localPosition.z);

                }
                else
                {
                    WeaponspriteRenderer.flipY = true;
                    equipHandler.equipedWeapon.firePoint.transform.localPosition = new Vector3(equipHandler.equipedWeapon.firePoint.transform.localPosition.x, -Mathf.Abs(equipHandler.equipedWeapon.firePoint.transform.localPosition.y), equipHandler.equipedWeapon.firePoint.transform.localPosition.z);
                }
            }

        }
    }
}


