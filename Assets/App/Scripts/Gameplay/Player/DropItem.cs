using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DropItem : MonoBehaviour
{
    [Header("Main Settings")]
    public string TagObject;
    public UnityEvent TriggerEvent;
    public bool DestroyTrigger;
    public bool DestroyThisGameObject;



    public SpriteRenderer SR;
    public bool enableSwap;

    private void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        enableSwap = false;
    }

    public void SwapItemObject(SpriteRenderer sr)
    {
        SR = sr;
    }


    public void SetEnableSwap( bool enable)
    {
        enableSwap = enable;
    }

    public void SwapItemOtherObject(Collider2D other)
    { 
        if (enableSwap)
        {
            SpriteRenderer sr = other.GetComponent<SpriteRenderer>();
            SpriteRenderer temp = SR;
            SR = sr;
            sr = temp;
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == TagObject)
        {
            // other.GetComponent<WeaponManager>().SwapWeapon()
            if (DestroyTrigger)
            {
                Destroy(other.gameObject);
            }
            if (DestroyThisGameObject)
            {
                Destroy(gameObject);
            }
        }
    }


    private void Update()
    {
        
    }
}
