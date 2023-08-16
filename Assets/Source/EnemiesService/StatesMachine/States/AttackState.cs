using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class AttackState : State
{
    private Enemy _enemy;
    private IDamageble _target;
    private float _elapsedTime = 0;

    public AttackState(Enemy enemy, IDamageble target)
    {
        _enemy = enemy;
        _target = target;
    }

    public override void Update(float delta)
    {
        _elapsedTime += delta;

        if (_elapsedTime > _enemy.Config.SpeedAttack)
        {
            _elapsedTime = 0;
            _target.ApplyDamage(_enemy.Config.Damage);
        }
    }
}
