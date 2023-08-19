using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal abstract class Transition
{
    private State _targetState;
    private int _numberNeedTransit;

    public State TargetState => _targetState;
    public bool NeedTransit => _numberNeedTransit == 1;

    internal Transition(State targetState) => _targetState = targetState;

    public virtual void Update()
    {
        if (CanCountNumberNeedTransit() == false)
            return;
    }

    public bool CanCountNumberNeedTransit() => _numberNeedTransit < 2;
    
    public void CountNumberNeedTransit() => _numberNeedTransit++;

    public void ResetCountNumberNeedTransit() => _numberNeedTransit = 0;
}
