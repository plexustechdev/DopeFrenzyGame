using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionCombo : MonoBehaviour
{
    public string destructionTag;
    [Tooltip("Example 3 seconds")] public float comboCheckTime;
    public float startingTime;
    public float currentTime;
    PlayerResult playerResult;
    public int destructionCount;
    [Tooltip("is player have new kills in 3 seconds?")] public bool iscomboTimerActive;
    // public int currentDestruction;


    private void Awake()
    {
        playerResult = GetComponent<PlayerResult>();
        
    }
    void Start()
    {
        destructionCount = playerResult.vehicles;
    }

    // Update is called once per frame
    void Update()
    {
        if (iscomboTimerActive)
        {
            if (currentTime - startingTime <= comboCheckTime)
            {
                currentTime += Time.deltaTime;

            }
            else
            {
                iscomboTimerActive = false;
                currentTime = 0;
                startingTime = 0;
            }
        }

        if (DestructionCheck())
        {
            if (iscomboTimerActive)
            {

            }
            addDestructionCount();
        }

        if (playerResult.vehicles > destructionCount && !iscomboTimerActive)
        {
            iscomboTimerActive = true;
            startingTime = Time.deltaTime;
            currentTime = startingTime;
        }
    }

    public void addDestructionCount()
    {
        destructionCount++;
    }
    public bool DestructionCheck()
    {
        return playerResult.vehicles > destructionCount;

    }
    public void addMultiplier(float multiplier)
    {
        playerResult.multiplier = multiplier;
    }
}
