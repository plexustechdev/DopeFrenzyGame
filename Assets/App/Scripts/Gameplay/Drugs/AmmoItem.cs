using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoItem : MonoBehaviour
{
    public int ammo;
    [Header("Main Settings")]
    public string TagObject;
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == TagObject)
        {
            addAmmo(other.gameObject);
        }
    }

    public void addAmmo(GameObject other)
    {
        other.GetComponent<PlayerShoot>().addAmmo(ammo);
    }
}
