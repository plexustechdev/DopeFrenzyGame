using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspector_RandomPosition : MonoBehaviour
{
    [Tooltip("grid / area map game")] public BoxCollider2D mapBounds;

    public void RandomPosition()
    {
        float xMin = mapBounds.bounds.min.x;
        float xMax = mapBounds.bounds.max.x;
        float yMin = mapBounds.bounds.min.y;
        float yMax = mapBounds.bounds.max.y;
        float xPos = Random.Range(xMin, xMax);
        float yPos = Random.Range(yMin, yMax); 

        gameObject.GetComponent<Transform>().position = new Vector3(xPos, yPos, 0);
    }
}
