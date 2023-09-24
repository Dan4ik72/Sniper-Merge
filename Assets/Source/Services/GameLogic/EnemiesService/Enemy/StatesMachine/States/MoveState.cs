using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class MoveState : State
{
    private Enemy _enemy;
    private IDamageble _target;

    public MoveState(Enemy enemy, IDamageble target, AnimationEnemy animation) : base(animation)
    {
        _enemy = enemy;
        _target = target;
    }

    public override void Enter()
    {
        Animation.Move();
    }

    public override void Update(float delta)
    {
        _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, _target.Position, delta * _enemy.Config.Speed);
    }
}
