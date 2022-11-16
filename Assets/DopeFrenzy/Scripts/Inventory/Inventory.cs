using UnityEngine;
using UnityEngine.InputSystem;

namespace DopeFrenzy
{
    public class Inventory : InventoryBase
    {
        [SerializeField] private int m_Slot;
        public GameObject Stash;
        public override int Slot { get => m_Slot; set => m_Slot = value; }

        void Start()
        {
            InputManager.instance.inputPlayer.Player.Interact.performed += PickUp;
        }

        public override void PickUp(InputAction.CallbackContext context)
        {
            if (Stash)
            {
                EquipHandler equipHandler = GetComponent<Character>().characterEquip;

                equipHandler.PickUpWeapon(Stash.GetComponent<Weapon>());

            }
        }





    }

}

