using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

internal abstract class State
{
    private List<Transition> _transitions = new();

    public bool IsActive { get; protected set; }
    protected Transform Target { get; private set; }

    public State(List<Transition> transition, Transform target)
    {
        _transitions = transition;
        Target = target;
        IsActive = false;
    }

    public void Enter(Transform target)
    {
        if (IsActive == false)
            IsActive = true; 
    }
    
    public void Exit()
    {
        if (IsActive == true)
            IsActive = false;
    }

    public State GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
                return transition.TargetState;
        }

        return null;
    }

    public abstract void Update();
}
