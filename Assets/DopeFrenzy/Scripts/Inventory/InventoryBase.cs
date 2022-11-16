using UnityEngine;
using UnityEngine.InputSystem;

namespace DopeFrenzy
{
    public abstract class InventoryBase : MonoBehaviour
    {
        public abstract int Slot{set;get;}

        public abstract void PickUp(InputAction.CallbackContext context);

    }
}


