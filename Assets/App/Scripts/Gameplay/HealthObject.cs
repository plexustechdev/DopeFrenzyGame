using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthObject : MonoBehaviour
{
    public string BulletTagObject;
    public bool DestroyTrigger;
    public bool DestroyThisGameObject;

    public float startingHealth;
    public float currentHealth;

    [Header("Event Condition Health")]
    public float ConditionHealth;
    public UnityEvent ConditionEvent;
    bool isExecuted = false;
    void Start()
    {
        currentHealth = startingHealth;

    }

    public void addHealth(float health)
    {
        currentHealth += health;

    }
    public void takeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == BulletTagObject)
        {
            takeDamage(other.gameObject.GetComponent<BulletDamage>().Damage);
            if (DestroyTrigger)
            {
                Destroy(other.gameObject);
            }
            if (DestroyThisGameObject)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        //memeriksa jika event belum pernah dieksekusi
        if (!isExecuted)
        {
            //cek nilai kondisi dengan nilai variabel
            if (currentHealth <= ConditionHealth)
            {
                ConditionEvent.Invoke();
            }
        }

    }
}
