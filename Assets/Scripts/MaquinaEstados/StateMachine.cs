using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine 
{
    public abstract void EnterState();
    public virtual void UpdateState()
    {
        
    }
    public abstract void ExitSatate();

    
    
}
