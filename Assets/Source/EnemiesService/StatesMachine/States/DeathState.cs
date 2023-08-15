using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class DeathState : State
{
    private Enemy _enemy;
    private Transform _target;

    public DeathState(Enemy enemy, Transform target)
    {
        _enemy = enemy;
        _target = target;
    }

    public override void Update(float delta)
    {

    }
}
