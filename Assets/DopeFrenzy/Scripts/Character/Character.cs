using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DopeFrenzy
{
    public class Character : MonoBehaviour, IDamagable
    {
        [Header("Character's Attributes")]
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _Accuracy;
        public float MovementSpeed
        {
            set
            {
                _movementSpeed = value;
                characterController.OnSpeedChange(value);
            }

            get { return _movementSpeed; }
        }

        public float Accuracy { set => _Accuracy = value; get => _Accuracy; }



        [Header("References")]
        [HideInInspector] public BaseController characterController;
        [HideInInspector] public CharacterHealth characterHealth;
        [HideInInspector] public Inventory characterInventory;
        [HideInInspector] public EquipHandler characterEquip;


        void Start()
        {
            //GET REFERENCES
            if (!characterController)
                characterController = GetComponent<BaseController>();
            characterHealth = GetComponent<CharacterHealth>();
            characterInventory = GetComponent<Inventory>();
            characterEquip = transform.Find("equip").GetComponent<EquipHandler>();


            //Init Stat
            Initialize();
        }

        void Initialize(){
            MovementSpeed = _movementSpeed;
            Accuracy = _Accuracy;
        }


        public void Destroy()
        {
            //IDK
        }

        public void TakeDamage(float damage, Character attacker)
        {

            Vector2 dir = (attacker.transform.position - transform.position).normalized;
            Vector2 generalDirection = new Vector2(Mathf.Round(dir.x), Mathf.Round(dir.y));

            characterHealth.ReduceHealth(damage, generalDirection, attacker);
            
        }


    }
}

