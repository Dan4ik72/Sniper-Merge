using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal abstract class State
{
    private IReadOnlyList<Transition> _transitions;

    public bool IsActive { get; protected set; } = false;

    public abstract void Update(float delta);

    public void Enter()
    {
        if (IsActive == false)
            IsActive = true;

        ResetTransitions();
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
            transition.Update();

            if (transition.NeedTransit)
            {
                return transition.TargetState;
            }
        }

        return null;
    }

    public void ResetTransitions()
    {
        foreach (var transition in _transitions)
            transition.ResetCountNumberNeedTransit();
    }

    public void AddTransitions(IReadOnlyList<Transition> transitions)
    {
        _transitions = transitions;
    }
}
