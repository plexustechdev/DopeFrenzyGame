using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ResistPowerUp : Drug
{
    public float timeResist;
    [Header("Main Settings")]
    public string TagObject;
    [Tooltip("turn on to destroy game object after the player touch this game objet")] public bool destroyGameObject;
    public UnityEvent TriggerEvent;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == TagObject)
        {
            // addResist(other.gameObject);
            ResistPowerUp Resistance = other.gameObject.AddComponent<ResistPowerUp>();
            Resistance.DrugEffectName = DrugEffectName;
            Resistance.EffectTime = EffectTime;
            Resistance.timeResist = timeResist;
            other.GetComponent<DrugsHandler>().addDrug(Resistance);
            InvokeTrigger();
            if (destroyGameObject == true)
            {
                Destroy(gameObject);
            }
        }
    }

    public void InvokeTrigger()
    {
        TriggerEvent.Invoke();
    }

    public void addResist(GameObject other)
    {
        other.GetComponent<HealthPlayer>().addResist(true, timeResist);
        if (destroyGameObject)
        {
            Destroy(gameObject);
        }
    }
}
