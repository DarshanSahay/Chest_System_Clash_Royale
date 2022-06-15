using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedState : States
{
    [SerializeField] private UnlockingState unlocking;
    [SerializeField] private ChestView view;

    public override States RunCurrentState()
    {
        if(view.hasStarted == true)
        {
            return unlocking;
        }
        return this;
    }
}
