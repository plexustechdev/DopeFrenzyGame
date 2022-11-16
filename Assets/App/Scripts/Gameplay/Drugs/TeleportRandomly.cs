using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportRandomly : Drug
{
    public string TagObject;
    [Tooltip("turn on to destroy game object after the player touch this game objet")]public bool destroyGameObject;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == TagObject)
        {
            // Teleport(other.gameObject);
            TeleportRandomly TR = other.gameObject.AddComponent<TeleportRandomly>();
            TR.DrugEffectName = DrugEffectName;
            TR.EffectTime = EffectTime;
            other.GetComponent<DrugsHandler>().addDrug(TR);

            if (destroyGameObject)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Teleport(GameObject other)
    {
        other.GetComponent<Inspector_RandomPosition>().RandomPosition();
        if (destroyGameObject)
        {
            Destroy(gameObject);
        }
    }
}
