using UnityEngine;
using UnityEngine.InputSystem;

namespace DopeFrenzy
{
    public class Controller : BaseController
    {
        [SerializeField] private LayerMask m_CollidableLayer;
        private float _moveSpeed;
        private Weapon currentWeapon;
        protected override float moveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
        protected override LayerMask Collidable { get => m_CollidableLayer; set => m_CollidableLayer = value; }


        public override void OnSpeedChange(float speed)
        {
            base.OnSpeedChange(speed);
        }
    }

}

