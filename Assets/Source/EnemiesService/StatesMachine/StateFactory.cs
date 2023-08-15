using System.Collections.Generic;
using UnityEngine;
using VContainer;

internal class StateFactory
{
    private Enemy _enemy;
    private Transform _target;
    private State _firstState;

    [Inject]
    public StateFactory(Enemy enemy, Transform target)
    {
        _enemy = enemy;
        _target = target;
    }

    public State FirstState => _firstState;

    public void CreateStates()
    {
        List<State> _states = new();
        List<Transition> transitions = new();

        var moveState = new MoveState(_enemy, _target);
        _states.Add(moveState);
        var moveTransition = new MoveTransition(moveState, _enemy, _target);
        transitions.Add(moveTransition);

        var attackState = new AttackState(_enemy, _target);
        _states.Add(attackState);
        var attackTransition = new AttackTransition(attackState, _enemy, _target);
        transitions.Add(attackTransition);

        var deathState = new DeathState(_enemy, _target);
        _states.Add(deathState);
        var deathTransition = new DeathTransition(deathState, _enemy, _target);
        transitions.Add(deathTransition);

        var victoryState = new VictoryState(_enemy, _target);
        _states.Add(victoryState);
        var victoryTransition = new VictoryTransition(victoryState, _enemy, _target);
        transitions.Add(victoryTransition);

        _firstState = deathState;

        foreach (var transition in transitions)
            transition.ResetCountNumberNeedTransit();

        foreach (var state in _states)
            state.AddAllTransitions(transitions);
    }
}
