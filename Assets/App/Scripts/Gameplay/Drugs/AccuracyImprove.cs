using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccuracyImprove : Drug
{
    // public static AccuracyImprove instance;

    [Header("Main Settings")]
    public string TagObject;
    public float accuration;
    [Tooltip("turn on to destroy game object after the player touch this game objet")] public bool destroyGameObject;

    private void Awake()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == TagObject)
        {
            // ActivateDrug(other);
            // other.GetComponent<PlayerShoot>().GetDrugAccuration(100, EffectTime);
            AccuracyImprove AI = other.gameObject.AddComponent<AccuracyImprove>();
            AI.DrugEffectName = DrugEffectName;
            AI.EffectTime = EffectTime;
            AI.accuration = accuration;
            other.GetComponent<DrugsHandler>().addDrug(AI);

            if (destroyGameObject)
            {
                Destroy(gameObject);
            }
        }
    }

    /*public void ActivateDrug()
    {
        gameObject.GetComponent<PlayerShoot>().GetDrugAccuration(100, EffectTime);
    }*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
