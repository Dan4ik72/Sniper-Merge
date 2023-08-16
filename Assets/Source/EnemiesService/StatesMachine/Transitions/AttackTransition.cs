using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class AttackTransition : Transition
{
    private Enemy _enemy;
    private IDamageble _target;

    public AttackTransition(State targetState, Enemy enemy, IDamageble target) : base(targetState)
    {
        _enemy = enemy;
        _target = target;
    }

    public override void Update()
    {
        if (CanCountNumberNeedTransit())
        {
            if (_enemy.IsAlive && _target.IsAlive && Vector3.Distance(_enemy.transform.position, _target.Position) < 0.1f)
            {
                CountNumberNeedTransit();
            }
        }
    }
}
