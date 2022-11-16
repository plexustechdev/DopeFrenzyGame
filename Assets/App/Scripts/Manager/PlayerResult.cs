using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerResult : MonoBehaviour
{

    public int kills;
    public TMP_Text killsText;
    public int vehicles;
    public TMP_Text vehicleText;
    public float score;
    public TMP_Text scoreText;

    public float multiplier;

    // Start is called before the first frame update
    void Start()
    {
        kills = 0;
        killsText.text = kills.ToString();
        vehicles = 0;
        vehicleText.text = vehicles.ToString();
    }

    public void addKills()
    {
        kills ++;
        killsText.text = kills.ToString();
    }

    public void addVehicles()
    {
        vehicles++;
        vehicleText.text = vehicles.ToString();
    }
    
    public void AddScore(float add)
    {
        // string format = "###,###,###";
        score += add;
        scoreText.text = score.ToString("000000000");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
