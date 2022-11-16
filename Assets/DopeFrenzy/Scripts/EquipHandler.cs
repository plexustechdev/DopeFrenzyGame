using UnityEngine;
using UnityEngine.InputSystem;

namespace DopeFrenzy
{
    public class EquipHandler : MonoBehaviour
    {
        public Weapon equipedWeapon;

        public Weapon primaryWeapon;
        public Weapon secondaryWeapon;

        public bool isEquiped = false;
        public Character m_Character;


        void Start()
        {
            m_Character = transform.parent.GetComponent<Character>();
            if (transform.childCount > 0)
            {
                equipedWeapon = transform.GetChild(0).GetComponent<Weapon>();
            }
            InputManager.instance.inputPlayer.Player.Fire.performed += OnFire;
            InputManager.instance.inputPlayer.Player.DropItem.performed += Drop;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                Equip(primaryWeapon);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Equip(secondaryWeapon);
            }
        }

        public void PickUpWeapon(Weapon weapon) {

            weapon.gameObject.SetActive(false);
            weapon.transform.SetParent(transform);
            weapon.transform.localPosition = new Vector3(0, 0, 0);

            if (weapon.weaponType.ToString() == "Primary")
            {
                if (primaryWeapon != null) {
                    DoDrop(primaryWeapon,true);
                }

                primaryWeapon = weapon;

                if (equipedWeapon != null)
                {
                    if (equipedWeapon.weaponType.ToString() == "Primary")
                    {
                        Equip(weapon);
                    }
                }
                else {
                    Equip(weapon);
                }
            }

            if (weapon.weaponType.ToString() == "Secondary")
            {
                if (secondaryWeapon != null)
                {
                    DoDrop(secondaryWeapon,true);
                }

                secondaryWeapon = weapon;

                if (equipedWeapon != null)
                {
                    if (equipedWeapon.weaponType.ToString() == "Secondary")
                    {
                        Equip(weapon);
                    }
                }
                else {
                    Equip(weapon);
                }
            }
        }

        public void Equip(Weapon weapon)
        {
            if (primaryWeapon != null)
            {
                primaryWeapon.gameObject.SetActive(false);
            }

            if (secondaryWeapon != null)
            {
                secondaryWeapon.gameObject.SetActive(false);
            }

            equipedWeapon = weapon;
            weapon.gameObject.SetActive(true);
            isEquiped = true;
            UIManager.instance.UpdateWeapon(weapon.GetComponent<SpriteRenderer>().sprite);
        }

        public void Drop(InputAction.CallbackContext context)
        {
            DoDrop(equipedWeapon,false);
        }

        public void DoDrop(Weapon weapon, bool dropOnPickUp)
        {
            if (!dropOnPickUp) {
                if (weapon.weaponType.ToString() == "Secondary")
                {
                    if (equipedWeapon.weaponType.ToString() == "Secondary" && primaryWeapon != null)
                    {
                        Equip(primaryWeapon);
                    }

                    secondaryWeapon = null;
                }

                if (weapon.weaponType.ToString() == "Primary")
                {

                    if (equipedWeapon.weaponType.ToString() == "Primary" && secondaryWeapon != null)
                    {
                        Equip(secondaryWeapon);
                    }

                    primaryWeapon = null;
                }
            }


            weapon.gameObject.SetActive(true);
            weapon.transform.SetParent(null);
            weapon.transform.right = Vector3.zero;
            weapon.transform.position = new Vector3(equipedWeapon.transform.position.x, m_Character.GetComponent<Collider2D>().bounds.center.y - (m_Character.GetComponent<Collider2D>().bounds.size.y / 2), equipedWeapon.transform.position.z);

            if (primaryWeapon == null && secondaryWeapon == null)
            {
                equipedWeapon = null;
                isEquiped = false;
                UIManager.instance.UpdateWeapon(null);
            }

            this.transform.right = Vector3.zero;         
        }

        protected void OnFire(InputAction.CallbackContext context)
        {

            if (!isEquiped)
            {
                return;
            }

            equipedWeapon.Fire(m_Character);
        }
    }
}


