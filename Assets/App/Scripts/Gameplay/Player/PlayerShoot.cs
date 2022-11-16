using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform firepoint;
    public float distanceFirePointX;
    public float distanceFirePointY;
    public int startingAmmo;
    public int currentAmmo;
    public TMP_Text currentAmmoText;

    [Header("Shoot Accuration")]
    public float maxRandomAccuration;
    public float startPercentageAcuration;
    [SerializeField] float percentageAcuration;
    [Header("PoweUp Accuration handler")]
    public float EffectTimer;
    
    void Start()
    {
        currentAmmo = startingAmmo;
        currentAmmoText.text = currentAmmo.ToString() + "/" + startingAmmo.ToString();
        percentageAcuration = startPercentageAcuration;
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetMouseButtonDown(0) && currentAmmo > 0)
        {
            Shoot();
            currentAmmo -= 1;
            currentAmmoText.text = currentAmmo.ToString() + "/" + startingAmmo.ToString();
        }
        // if (Input.GetMouseButtonDown(1))
        if (Input.GetKeyDown(KeyCode.R))
        {
            reload();
        }

        if (EffectTimer > 0)
        {
            EffectTimer -= Time.deltaTime;
        } else
        {
            percentageAcuration = startPercentageAcuration;
        }
    }

     public void Shoot()
    {
        Vector3 firePosition = new Vector3(firepoint.position.x + distanceFirePointX, firepoint.position.y + distanceFirePointY,0);

        // set accurracy
        // float randompoint = AccuracyImprove.instance.RandomAccurracy(percentageAcuration);
        float randompoint = getRandomAccurration(percentageAcuration);
        //print(randompoint.ToString());

        // set direction
        firepoint.eulerAngles = new Vector3(firepoint.rotation.x, firepoint.rotation.y, firepoint.eulerAngles.z + randompoint);

        // instantiate object
        Instantiate(bullet, firepoint.position, firepoint.rotation);


    }

    public void addAmmo(int ammo)
    {
        currentAmmo += ammo;
        currentAmmoText.text = currentAmmo.ToString() + "/" + startingAmmo.ToString();
    }

    public void reload()
    {
        currentAmmo = startingAmmo;
        currentAmmoText.text = currentAmmo.ToString() + "/" + startingAmmo.ToString();
    }

    public float getRandomAccurration(float percentageAccuracy)
    {
        float range = maxRandomAccuration - maxRandomAccuration * (percentageAccuracy / 100);
        float randomRange = Random.Range(-range, range);

        return randomRange;
    }

    public void GetDrugAccuration(float accuration, float time)
    {
        percentageAcuration += accuration;
        if (percentageAcuration >= 100)
        {
            percentageAcuration = 100;
        }
        EffectTimer = time;
    }
}
