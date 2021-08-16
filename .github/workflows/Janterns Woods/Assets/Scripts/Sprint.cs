using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sprint : MonoBehaviour
{
    [SerializeField]
    private int maxSprint = 300;

    public int currentSprint;

    public int i;

    public int j;

    public Player player;

    public event Action<float> OnSprintPctChanged = delegate { };

    // Use this for initialization
    private void OnEnable()
    {
        currentSprint = maxSprint;
        
    }

    public void ModifySprint(int amount)
    {
        currentSprint += amount;

        float currentSprintPct = (float)currentSprint / (float)maxSprint;
        OnSprintPctChanged(currentSprintPct);
    }

    // Update is called once per frame
    private void Update ()
    {
        if (Input.GetKey(KeyCode.Space) && currentSprint > 0 && player.point == true)
        {
            ModifySprint(-1);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            i = 0;
        }

        //Current Sprint & Max Sprint rules
        //======================================
        if (currentSprint > maxSprint)
        {
            currentSprint = maxSprint;
        }

        if (i < 10 && currentSprint < maxSprint)
        {
            i++;
        }
        //=======================================

        if (player.bSprint == false)
        {
            if (j < 10)
            {
                j++;
            }

            if (j == 10)
            {
                ModifySprint(2);
                i = 0;
                j = 0;
            }
            
        }

    }
}
