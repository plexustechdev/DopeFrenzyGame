using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class timer : MonoBehaviour
{
    public float startTime;
    private float currentTime;
    [SerializeField] private TMP_Text timerText;

    private void Awake()
    {
        currentTime = startTime;
    }
    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(currentTime / 60);
            float seconds = Mathf.FloorToInt(currentTime % 60); //modulus
            timerText.text = string.Format("{0:00}: {1:00}", minutes, seconds);
        }
    }
}
