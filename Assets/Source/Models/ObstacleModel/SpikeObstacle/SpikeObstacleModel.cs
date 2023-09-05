using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class SpikeObstacleModel
{
    private readonly int _damage;
    private readonly int _durabilityDecreasingStep;
    private readonly float _damageTickRate;

    private int _durability;

    private Dictionary<IDamageble, CancellationTokenSource> _currentDamageables = new();

    public event Action ObstacleBroke;

    public SpikeObstacleModel(int damage, int durability, int durabilityDecreasingStep, float damageTickRate)
    {
        _damage = damage;
        _durability = durability;
        _durabilityDecreasingStep = durabilityDecreasingStep;
        _damageTickRate = damageTickRate;
    }

    public void OnTriggerEnter(Collider entered)
    {
        if(entered.gameObject.TryGetComponent(out IDamageble damagable) == false)
            return;

        var cancellationTokenSource = new CancellationTokenSource();
        _currentDamageables.Add(damagable, cancellationTokenSource);
        damagable.Died += OnCurrentDamageableDied;

        MakingDamage(damagable, cancellationTokenSource.Token);
    }

    public void OnTriggerExit(Collider exited)
    {
        if (exited.gameObject.TryGetComponent(out IDamageble damageble) == false)
            return;

        if(_currentDamageables.ContainsKey(damageble) == false)
            return;

        _currentDamageables[damageble].Cancel();
        _currentDamageables.Remove(damageble);
    }
    
    private async UniTask MakingDamage(IDamageble damagable, CancellationToken token)
    {
        while (token.IsCancellationRequested == false)
        {   
            MakeDamage(damagable);
            DecreaseDurability();
            
            await UniTask.WaitForSeconds(_damageTickRate, cancellationToken: token);
        }
    }

    private void DecreaseDurability()
    {
        _durability = Mathf.Clamp(_durability - _durabilityDecreasingStep, 0, _durability);

        if(_durability <= 0)
            OnObstacleBroke();
    }

    private void OnCurrentDamageableDied(IDamageble damageable)
    {
        if (_currentDamageables.ContainsKey(damageable) == false)
            return;

        _currentDamageables[damageable].Cancel();
        _currentDamageables.Remove(damageable);
    }

    private void OnObstacleBroke()
    {
        foreach (var keyValuePair in _currentDamageables)
            keyValuePair.Value.Cancel();
        
        _currentDamageables.Clear();
        
        ObstacleBroke?.Invoke();
    }

    private void MakeDamage(IDamageble damagable) => damagable.ApplyDamage(_damage);
}