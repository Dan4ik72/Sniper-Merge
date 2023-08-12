using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class AttackTransition : Transition
{
    private Transform _position;

    public AttackTransition(State targetState, Transform target) : base(targetState, target) { }

    public override void Update()
    {
        if (CanCountNumberNeedTransit())
        {
            if (Vector3.Distance(_position.position, Target.position) < 0)
            {
                CountNumberNeedTransit();
            }
        }
    }
}
