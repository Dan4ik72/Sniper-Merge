using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

internal class DeathState : State
{
    private Enemy _enemy;
    private float _speedFall = 0.5f;

    public DeathState(Enemy enemy, AnimationEnemy animation) : base(animation)
    {
        _enemy = enemy;
    }

    public override void Enter()
    {
        Animation.Die();
        StartDeath();
    }

    public override void Update(float delta)
    {

    }

    public async UniTask StartDeath()
    {
        await UniTask.WaitForSeconds(4);

        float elapsedTime = 0, fallTime = 2;

        while (fallTime > elapsedTime)
        {
            elapsedTime += Time.deltaTime;
            _enemy.GetTransform().position = Vector3.MoveTowards(_enemy.Position, _enemy.Position + Vector3.down, _speedFall * Time.deltaTime);
            await UniTask.Yield();
        }

        _enemy.Clear();
    }
}
