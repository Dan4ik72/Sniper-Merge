using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class VictoryState : State
{
    private Enemy _enemy;

    public VictoryState(Enemy enemy)
    {
        _enemy = enemy;
    }

    public override void Update(float delta)
    {
        _enemy.transform.localScale = Vector3.one * 2;
    }
}
