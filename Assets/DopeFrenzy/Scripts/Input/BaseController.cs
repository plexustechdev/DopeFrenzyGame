using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DopeFrenzy
{

    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class BaseController : MonoBehaviour
    {
        public MovementState movementState;
        public FacingTo facingTo;


        protected InputPlayer inputPlayer;

        protected abstract float moveSpeed { set; get; }
        protected abstract LayerMask Collidable { set; get; }

        private Animator anim;
        private Rigidbody2D rb;
        private bool isInputEnabled = true;
        [SerializeField] private bool isRunning;


        public enum MovementState
        {
            Idle,
            Walking,
            Running
        }

        public enum FacingTo
        {
            Up,
            Right,
            Down,
            Left
        }


        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            transform.Find("root").TryGetComponent<Animator>(out anim);
            inputPlayer = new InputPlayer();
            inputPlayer.Enable();


            InputManager.instance.inputPlayer.Player.Move.canceled += OnMoveCanceled;
            InputManager.instance.inputPlayer.Player.Run.started += OnRun;
            InputManager.instance.inputPlayer.Player.Run.canceled += OnStopRun;
        }

        void FixedUpdate()
        {
            Vector2 moveValue = inputPlayer.Player.Move.ReadValue<Vector2>();
            rb.MovePosition(rb.position + moveValue * moveSpeed * Time.fixedDeltaTime);
            anim.SetFloat("horizontal", moveValue.x);
            anim.SetFloat("vertical", moveValue.y);



            //STATES
            if (moveValue != Vector2.zero && !isRunning)
            {
                movementState = MovementState.Walking;
            }else if(isRunning){
                movementState = MovementState.Running;
            }



            UpdateFacing(moveValue);
            UpdateAnimation(movementState, facingTo);
        }


        void UpdateAnimation(MovementState moveState, FacingTo facingTo)
        {
            anim.SetInteger("state", (int)moveState);
            anim.SetInteger("facingTo", (int)facingTo);
        }

        void UpdateFacing(Vector2 movement)
        {
            if (movement == Vector2.up)
            {
                facingTo = FacingTo.Up;
            }
            else if (movement == Vector2.down)
            {
                facingTo = FacingTo.Down;
            }
            else if (movement == Vector2.left)
            {
                facingTo = FacingTo.Left;
            }
            else if (movement == Vector2.right)
            {
                facingTo = FacingTo.Right;
            }
        }

        public virtual void OnSpeedChange(float speed)
        {
            moveSpeed = speed;
        }


        void OnMoveCanceled(InputAction.CallbackContext context)
        {
            movementState = MovementState.Idle;
        }

        protected virtual void OnRun(InputAction.CallbackContext context)
        {
            moveSpeed = moveSpeed * 2f;
            isRunning = true;
            anim.SetBool("isRunning", true);
            UpdateAnimation(movementState, facingTo);
        }

        protected virtual void OnStopRun(InputAction.CallbackContext context)
        {
            moveSpeed = moveSpeed / 2f;
            isRunning = false;
            anim.SetBool("isRunning", false);
            UpdateAnimation(movementState, facingTo);
        }

        public void EnableInput(bool val)
        {
            isInputEnabled = val;
        }

    }

}

