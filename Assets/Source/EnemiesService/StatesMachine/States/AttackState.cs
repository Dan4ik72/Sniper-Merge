using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class AttackState : State
{
    private Enemy _enemy;
    private Transform _target;

    public AttackState(Enemy enemy, Transform target)
    {
        _enemy = enemy;
        _target = target;
    }

    public override void Update(float delta)
    {

    }
}
