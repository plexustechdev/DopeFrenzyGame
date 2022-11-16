using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : Drug
{

    // public string DrugEffectName;
    public int health;
    
    [Header("Main Settings")]
    public string TagObject;
    [Tooltip("turn on to destroy game object after the player touch this game objet")] public bool destroyGameObject;

    /*public static HealthItem instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            
            instance = this;
        }
    }*/
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == TagObject)
        {
            // addHealth(other.gameObject);
            // other.gameObject.AddComponent<HealthItem>();

            HealthItem HI = other.gameObject.AddComponent<HealthItem>();
            HI.DrugEffectName = DrugEffectName;
            HI.EffectTime = EffectTime;
            HI.health = health;
            other.GetComponent<DrugsHandler>().addDrug(HI);

            if (destroyGameObject)
            {
                Destroy(gameObject);
            }
        }
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == TagObject)
        {
            other.GetComponent<DrugsHandler>().addDrug(this);
            other.gameObject.AddComponent<HealthItem>();
            other.GetComponent<HealthItem>().EffectTime = EffectTime;
            other.GetComponent<HealthItem>().health = health;
        }
    }*/

    public void addHealth(GameObject other)
    {
        other.GetComponent<HealthPlayer>().addHealth(health);
        if (destroyGameObject)
        {
            Destroy(gameObject);
        }
    }
}
