using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class VictoryState : State
{
    private Enemy _enemy;

    public VictoryState(Enemy enemy, AnimationEnemy animation) : base(animation)
    {
        _enemy = enemy;
    }

    public override void Enter()
    {
        Animation.Win();
    }

    public override void Update(float delta)
    {

    }
}
