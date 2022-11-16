using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;
public class HealthPlayer : MonoBehaviour
{
    public string BulletTagObject;
    public bool DestroyTrigger;
    public bool DestroyThisGameObject;
    // public DrugPlayerManager DrugsPlayer;
    public float startingHealth;
    public float currentHealth;
    public bool isResist;
    public TMP_Text healthText;
    public Slider healthSlider;
    public float timeResist;

    [Header("Event Condition Health")]
    public float ConditionHealth;
    public UnityEvent ConditionEvent;
    bool isExecuted = false;


    public void takeDamage(float damage)
    {
        // float damageValue = damage - resist;

        float damageValue = isResist ? damage * 0 : damage;
        currentHealth -= damageValue;
        healthText.text = currentHealth.ToString();
        healthSlider.value = currentHealth / startingHealth;
    }

    void Start()
    {
        // DrugsPlayer = gameObject.GetComponent<DrugPlayerManager>();
        currentHealth = startingHealth;
        isResist = false;
        timeResist = 0;
        healthText.text = currentHealth.ToString();
        healthSlider.value = currentHealth / startingHealth;
    }

    public void addHealth(float health)
    {
        currentHealth += health;
        healthText.text = currentHealth.ToString();
        healthSlider.value = currentHealth / startingHealth;
    }


    

    public void addResist(bool res, float timeRes)
    {
        isResist = res;
        timeResist = timeRes;

        // DrugsPlayer.isInDrugEffect = true;
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

        if (timeResist > 0)
        {
            timeResist -= Time.deltaTime;
        }
        else
        {
            timeResist = 0;
            isResist = false;
            // DrugsPlayer.isInDrugEffect = false;
        }
    }
}
