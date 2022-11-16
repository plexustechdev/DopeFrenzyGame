using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Weapon : MonoBehaviour
{
    [Header("Main Settings")]
    public string TagObject;
    public bool enableSwap;
    public int WeaponNumber;
    public int NextWeaponNumber;
    public SpriteRenderer sr;
    public SpriteRenderer next_sr;
    public GameObject[] prefabs;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enableSwap && Input.GetKeyDown(KeyCode.E))
        {
            GameObject go = Instantiate(prefabs[NextWeaponNumber], gameObject.transform.position, gameObject.transform.rotation);
            Weapon w = go.GetComponent<Weapon>();
            w.TagObject = TagObject;
            w.WeaponNumber = NextWeaponNumber+1;
            w.prefabs = prefabs;
            Destroy(gameObject);
            
                
                // ItemSpawner.instance.InstantiateObject(NextWeaponNumber-1, gameObject);

        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == TagObject)
        {
            enableSwap = true;
            other.gameObject.GetComponent<WeaponManager>().setNextWeaponIndex(WeaponNumber);
           
        }        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == TagObject && enableSwap && Input.GetKeyDown(KeyCode.E))
        {
            enableSwap = true;
            ItemSpawner.instance.InstantiateObject(WeaponNumber - 1, other.gameObject);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enableSwap = false;
    }

}
