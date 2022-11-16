using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    private Vector3 direction;
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updatePosition();
    }

    private void updatePosition()
    {
        transform.position = getNextPosition();
    }

    internal void SetDirection(float x, float y)
    {
        direction.x = x;
        direction.y = y;
    }

    public Vector3 getNextPosition()
    {
        return transform.position + newPosition();
    }

    public Vector3 newPosition()
    {
        return direction * Time.deltaTime * speed;
    }

    internal void setYDirection(float v)
    {
        direction.y = v;
    }

    internal void setXDirection(float v)
    {
        direction.x = v;
    }

    public void SetDirection(Vector3 value)
    {
        direction = value;
    }

    public void SetDirection(Vector2 value)
    {
        direction.x = value.x;
        direction.y = value.y;
    }
}
