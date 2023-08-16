using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class VictoryTransition : Transition
{
    private Enemy _enemy;
    private IDamageble _target;

    public VictoryTransition(State targetState, Enemy enemy, IDamageble target) : base(targetState) 
    {
        _enemy = enemy;
        _target = target;
    }

    public override void Update()
    {
        if (CanCountNumberNeedTransit())
        {
            if (_target.IsAlive == false && _enemy.IsAlive)
            {
                CountNumberNeedTransit();
            }
        }
    }
}
