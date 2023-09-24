using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class AnimationEnemy
{
    private const string State = "State";
    private const int Moving = 0, Attacking = 1, Death = 2, Victory = 3;

    private Animator _animator;

    public AnimationEnemy(Animator animator) => _animator = animator;

    public void Move()
    {
        _animator.SetInteger(State, Moving);
    }

    public void Attack()
    {
        _animator.SetInteger(State, Attacking);
    }

    public void Die()
    {
        _animator.SetInteger(State, Death);
    }

    public void Win()
    {
        _animator.SetInteger(State, Victory);
    }
}
