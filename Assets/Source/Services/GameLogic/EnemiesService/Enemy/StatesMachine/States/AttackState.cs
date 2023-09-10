using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class AttackState : State
{
    private const int DamageableLayer = 3;
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
            var target = RayCastForward().collider.GetComponent<IDamageble>();

            if (target == null)
                _target.ApplyDamage(_enemy.Config.Damage);
            else
                target.ApplyDamage(_enemy.Config.Damage);
        }
    }

    private RaycastHit RayCastForward()
    {
        RaycastHit hit;
        var ray = new Ray(_enemy.transform.position, _enemy.transform.forward);
        Physics.Raycast(ray, out hit, _enemy.RaycastDistance, 1 << DamageableLayer);
        return hit;
    }
}
