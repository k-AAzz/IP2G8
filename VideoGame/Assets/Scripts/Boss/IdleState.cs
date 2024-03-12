using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public SlapState SlapState;
    public bool canSeePlayer = false;
    public override State RunCurrentState()
    {
        if (canSeePlayer)
        {
            return SlapState;
        }
        else
        {
            return this;
        }
    }
}
