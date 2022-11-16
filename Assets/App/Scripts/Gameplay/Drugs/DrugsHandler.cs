using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugsHandler : MonoBehaviour
{
    public PlayerShoot playerShoot;
    public HealthPlayer healthPlayer;
    public List<Drug> drugList;
    public int drugsCounter;
    public bool anyActiveDrug;
    public float drugTimer;
    // Start is called before the first frame update


    
    private void Awake()
    {
        playerShoot = gameObject.GetComponent<PlayerShoot>();
        healthPlayer = gameObject.GetComponent<HealthPlayer>();
        // drugs = new Drug[10];
    }

    public void DrugsCheck(List<Drug> Drugs)
    {
        if (drugsCounter > 0 && !anyActiveDrug)
        {
            
            anyActiveDrug = true;
            if (Drugs[0] != null)
            {
                Drugs[0].ActivateDrug();
                drugTimer = Drugs[0].EffectTime;
                anyActiveDrug = true;
            }
        }
        
    }

 

    public void addDrug(Drug newDrug)
    {
        
        drugList.Add(newDrug);
        drugsCounter++;

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DrugsCheck(drugList);

        if (drugTimer > 0 && anyActiveDrug)
        {
            drugTimer -= Time.deltaTime;
        } 

        if (drugTimer <= 0 && anyActiveDrug)
        {
            Destroy(drugList[0]);
            drugList.RemoveRange(0, 1);
            
            drugsCounter--;
            anyActiveDrug = false;
        }
        
    }
}
