using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal abstract class Transition
{
    private State _targetState;
    private int _numberNeedTransit;

    protected Transform Target { get; private set; }
    public State TargetState => _targetState;
    public bool NeedTransit => _numberNeedTransit == 1;

    public Transition(State targetState, Transform target)
    {
        _targetState = targetState;
        Target = target;
        _numberNeedTransit = 0;
    }

    public abstract void Update();

    public bool CanCountNumberNeedTransit()
    {
        if (_numberNeedTransit < 2)
            return true;

        return false;
    }

    public void CountNumberNeedTransit()
    {
        _numberNeedTransit++;
    }
}
