using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class MoveState : State
{
    private Enemy _enemy;
    private Transform _target;

    public MoveState(Enemy enemy, Transform target)
    {
        _enemy = enemy;
        _target = target;
    }

    public override void Update(float delta)
    {
        _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, _target.position, delta * _enemy.Config.Speed);
    }
}
