using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class DeathState : State
{
    private Enemy _enemy;

    public DeathState(Enemy enemy)
    {
        _enemy = enemy;
    }

    public override void Update(float delta)
    {

    }
}
