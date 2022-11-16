using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCombos : MonoBehaviour
{
    [Tooltip("Example 3 seconds")]public float comboCheckTime;
    public float startingTime;
    public float currentTime;
    PlayerResult playerResult;
    public int playerKills;
    [Tooltip("is player have new kills in 3 seconds?")]public bool iscomboTimerActive;
    public int currentKill;

    private void Awake()
    {
        playerResult = GetComponent<PlayerResult>();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerKills = playerResult.kills;
    }

    // Update is called once per frame
    void Update()
    {
        if (KillsCheck())
        {
            addKill();
        }


        if (playerResult.kills > playerKills && !iscomboTimerActive)
        {
            iscomboTimerActive = true;
            startingTime = Time.deltaTime;
            currentTime = startingTime;
        }
        

        if (iscomboTimerActive)
        {
            if (currentTime - startingTime <= comboCheckTime)
            {
               currentTime += Time.deltaTime;

            } else
            {
                iscomboTimerActive = false;
                currentTime = 0;
                startingTime = 0;
            }
        }






    }

    public void addKill()
    {
        playerKills++;
    }
    public bool KillsCheck()
    {
        return playerResult.kills > playerKills;
        
    }
    public void addMultiplier(float multiplier)
    {
        
    }
}
