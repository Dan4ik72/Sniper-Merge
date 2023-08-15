using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class DeathTransition : Transition
{
    private Enemy _enemy;
    private Transform _target;

    public DeathTransition(State targetState, Enemy enemy, Transform target) : base(targetState)
    {
        _enemy = enemy;
        _target = target;
    }

    public override void Update()
    {
        if (CanCountNumberNeedTransit())
        {
            if (_enemy.IsAlive == false)
            {
                CountNumberNeedTransit();
            }    
        }
    }
}
