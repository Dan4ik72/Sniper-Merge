using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

internal class EnemyStateMachine
{
    private State _firstState;
    private Transform _target;
    private State _currentState;

    [Inject]
    public EnemyStateMachine(State firstState, Transform target)
    {
        _firstState = firstState;
        _target = target;
    }

    public void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter(_target);
    }

    private void Reset()
    {
        _currentState = _firstState;

        if (_currentState != null)
            _currentState.Enter(_target);
    }
}
