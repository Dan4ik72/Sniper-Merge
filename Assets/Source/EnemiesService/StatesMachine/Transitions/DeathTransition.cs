using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class DeathTransition : Transition
{
    private EnemyInfo _enemy;

    public DeathTransition(State targetState, Transform target) : base(targetState, target) { }

    public override void Update()
    {
        if (CanCountNumberNeedTransit())
        {
            if (_enemy.Health == 0)
            {
                CountNumberNeedTransit();
            }    
        }
    }
}
