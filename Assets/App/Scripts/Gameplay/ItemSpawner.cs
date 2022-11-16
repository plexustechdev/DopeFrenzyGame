using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [Header("Main Settings")]
    public GameObject[] TargetPrefab;
    public GameObject TargetPosition;
    public static ItemSpawner instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
        }
    }
    public void InstantiateObject(int prefabs, GameObject target)
    {
        Instantiate(TargetPrefab[prefabs], target.transform.position, target.transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
