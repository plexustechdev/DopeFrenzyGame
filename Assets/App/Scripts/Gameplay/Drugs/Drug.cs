using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drug : MonoBehaviour
{
    public string DrugEffectName;
    public float EffectTime;

    internal void ActivateDrug()
    {
        if (DrugEffectName == "AccuracyImproves")
        {
            gameObject.GetComponent<PlayerShoot>().GetDrugAccuration(100, EffectTime);
        }
        if (DrugEffectName == "HealthRestored")
        {
            gameObject.GetComponent<HealthPlayer>().addHealth(30);
        }
        if (DrugEffectName == "TeleportsRandomly")
        {
            gameObject.GetComponent<Inspector_RandomPosition>().RandomPosition();
        }
        if (DrugEffectName == "DamageResist")
        {
            gameObject.GetComponent<HealthPlayer>().addResist(true, 15);
        }
        

    }
}
