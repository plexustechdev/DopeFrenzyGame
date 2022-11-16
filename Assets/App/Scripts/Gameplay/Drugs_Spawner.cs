using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drugs_Spawner : MonoBehaviour
{
    public float startTimer;
    [SerializeField] private float currentTimer;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private float range;
    [SerializeField] private float distanceCollider;
    [SerializeField] private LayerMask playerLayer;
    public string playerTag;

    [Header("Drug Spawn List")]
    public GameObject drugsPrefab;
    public GameObject InstantiatePos;
    [SerializeField]  private bool hasInstantiate;
    [SerializeField] private bool isPlayerOnArea;
    public GameObject drugInstantiate;


    void Start()
    {
        currentTimer = startTimer;
        hasInstantiate = false;
        isPlayerOnArea = false;
    }

    


    // Update is called once per frame
    void Update()
    {

        if (currentTimer > 0 && !isPlayerOnArea && !hasInstantiate)
        {

            currentTimer -= Time.deltaTime;
            if (hasInstantiate == false && currentTimer <= 0)
            {
                InstantianteDrug();
                SetHasInstantiate(true);
                ResetTimer();

            }
        }

        if (drugInstantiate == null)
        {
            hasInstantiate = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == playerTag)
        {
            ResetTimer();
            isPlayerOnArea = true;

        }
        //isPlayerOnArea = false;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            // SetHasInstantiate(false);
            isPlayerOnArea = false;
        }
    }





    public void setAtctiveTimer(bool set)
    {

    }


    public void InstantianteDrug()
    {
        if (drugInstantiate == null)
        {
            drugInstantiate = Instantiate(drugsPrefab, transform) as GameObject;
            drugInstantiate.transform.position = InstantiatePos.transform.position;
            hasInstantiate = true;
        }
        
    }


    public void ResetTimer()
    {
        currentTimer = startTimer;
    }

    public void SetHasInstantiate(bool set)
    {
        hasInstantiate = set;
    }
}
