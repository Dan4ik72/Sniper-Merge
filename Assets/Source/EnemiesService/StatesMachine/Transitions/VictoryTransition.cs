using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class VictoryTransition : Transition
{
    private Enemy _enemy;
    private Transform _target;

    public VictoryTransition(State targetState, Enemy enemy, Transform target) : base(targetState) 
    {
        _enemy = enemy;
        _target = target;
    }

    public override void Update()
    {
        
    }
}
