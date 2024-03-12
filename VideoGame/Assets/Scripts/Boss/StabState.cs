using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabState : State
{
    public GameObject me1;
    public GameObject me2;
    public GameObject me3;
    public GameObject me4;
    public GameObject me5;
    public GameObject me6;
    public GameObject me7;
    public GameObject me8;
    public GameObject me9;

    public bool stabdone = false;

    public IdleState IdleState;
    public void stab()
    {
        int randomValue = Random.Range(1, 9);

        if (randomValue == 1)
        {
            me1.SetActive(true);
            stabdone = true;
        }
        else if(randomValue == 2)
        {
            me2.SetActive(true);
            stabdone = true;
        }
        else if(randomValue == 3)
        {
            me3.SetActive(true);
            stabdone = true;
        }
        else if(randomValue == 4)
        {
            me4.SetActive(true);
            stabdone = true;
        }
        else if(randomValue == 5)
        {
            me5.SetActive(true);
            stabdone = true;
        }
        else if(randomValue == 6)
        { 
            me6.SetActive(true);
            stabdone = true;
        }
        else if(randomValue == 7)
        {
            me7.SetActive(true);
            stabdone = true;
        }
        else if(randomValue == 8)
        {
            me8.SetActive(true);
            stabdone = true;
        }
        else
        {
            me9.SetActive(true);
            stabdone = true;
        }
    }
    public override State RunCurrentState()
    {
        stab();
        if(stabdone)
        {
            return IdleState;
        }
        else
        {
            return this;
        }
    }
}
