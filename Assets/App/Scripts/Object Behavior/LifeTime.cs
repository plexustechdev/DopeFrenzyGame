using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    public float timeLife;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLife <= 0)
        {
            Destroy(gameObject);
        }
        timeLife -= Time.deltaTime;
    }

    
}
