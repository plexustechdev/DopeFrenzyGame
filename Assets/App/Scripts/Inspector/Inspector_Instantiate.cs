
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspector_Instantiate : MonoBehaviour
{

    [Header("Main Settings")]
    public GameObject TargetPrefab;
    public GameObject TargetPosition;

    public void InstantiateObject()
    {
        Instantiate(TargetPrefab, TargetPosition.transform.position, TargetPosition.transform.rotation);
    }


}
