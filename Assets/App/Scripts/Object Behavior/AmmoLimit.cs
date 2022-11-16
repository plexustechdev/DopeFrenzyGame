using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AmmoLimit : MonoBehaviour
{

    public int startingAmmo;
    [SerializeField] private int currentAmmo;
    public TMP_Text startingAmmoText;
    public TMP_Text currentAmmoText;

    private void Awake()
    {
        currentAmmo = startingAmmo;
        startingAmmoText.text = startingAmmo.ToString();
        currentAmmoText.text = currentAmmo.ToString();
    }

    public void Shoot()
    {
        if (currentAmmo <= 0)
        {
            currentAmmo -= 1;
            currentAmmoText.text = currentAmmo.ToString();
        }
        
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
