using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<GameObject> weapons;
    [SerializeField] private int currentIndex;
    public int NextWeaponIndex;

    [SerializeField] private bool enableSwap;

   
    void Start()
    {
       
        NormalizeWeapon();
        currentIndex = 0;
        weapons[currentIndex].SetActive(true);
        enableSwap = false;
    }

    public void setNextWeaponIndex(int num)
    {
        NextWeaponIndex = num;
    }

    public void SetEnableSwap(bool enable)
    {
        enableSwap = enable;
    }

    public void NormalizeWeapon()
    {
        for (int i = 0; i < weapons.Count ; i++)
        {
            weapons[i].SetActive(false);
        }
    }
    public void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            NormalizeWeapon();
            
            if (currentIndex+1 >= weapons.Count)
            {
                currentIndex = 0;
            }else
            {
                currentIndex++;
            }

            weapons[currentIndex].SetActive(true);
        }
        

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weapon")
        {
            collision.gameObject.GetComponent<Weapon>().NextWeaponNumber = currentIndex;
        }
    }

    public void DropWeapon()
    {
        GameObject go = weapons[currentIndex];
        // Instantiate(go, gameObject.transform.position, gameObject.transform.rotation);
    }

    public void SwapWeapon(int number)
    {
        NormalizeWeapon();
        currentIndex = number - 1;
        weapons[currentIndex].SetActive(true);
        /*if (enableSwap && Input.GetKeyDown(KeyCode.E))
        {
            NormalizeWeapon();
            currentIndex = number - 1;
            weapons[currentIndex].SetActive(true);
        }*/

    }

    // Update is called once per frame
    void Update()
    {
        if (enableSwap && Input.GetKeyDown(KeyCode.E))
        {
            DropWeapon();
            SwapWeapon(NextWeaponIndex);

        }
    }
}
