using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

internal class EnemyStateMachine
{
    private StateFactory _stateFactory;
    private State _firstState;
    private State _currentState;

    public EnemyStateMachine(StateFactory stateFactory)
    {
        _stateFactory = stateFactory;
        _firstState = _stateFactory.FirstState;
    }

    public void Update(float delta)
    {
        if (_currentState == null)
            return;

        _currentState.Update(delta);
        var nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    public void Reset()
    {
        _currentState = _firstState;

        if (_currentState != null)
            _currentState.Enter();
    }

    private void Transit(State nextState)
    {
        if (_currentState != nextState)
        {
            _currentState.Exit();
            _currentState = nextState;
            _currentState.Enter();
        }
    }
}
