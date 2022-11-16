using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Moveable))]
public class MoveForward : MonoBehaviour
{
    private Moveable moveable;

    private void Awake()
    {
        moveable = GetComponent<Moveable>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveable.SetDirection(transform.up);
    }
}
