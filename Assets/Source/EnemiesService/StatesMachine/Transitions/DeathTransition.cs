using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class DeathTransition : Transition
{
    private Enemy _enemy;

    public DeathTransition(State targetState, Enemy enemy) : base(targetState)
    {
        _enemy = enemy;
    }

    public override void Update()
    {
        if (CanCountNumberNeedTransit())
        {
            if (_enemy.IsAlive == false)
            {
                CountNumberNeedTransit();
            }    
        }
    }
}
