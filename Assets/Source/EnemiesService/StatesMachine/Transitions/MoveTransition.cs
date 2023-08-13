using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class MoveTransition : Transition
{
    private Enemy _enemy;
    private Transform _target;

    public MoveTransition(State targetState, Enemy enemy, Transform target) : base(targetState)
    {
        _enemy = enemy;
        _target = target;
    }

    public override void Update()
    {
        if (CanCountNumberNeedTransit())
        {
            if (_enemy.IsAlive && Vector3.Distance(_enemy.transform.position, _target.position) > 0)
            {
                CountNumberNeedTransit();
            }
        }
    }
}
