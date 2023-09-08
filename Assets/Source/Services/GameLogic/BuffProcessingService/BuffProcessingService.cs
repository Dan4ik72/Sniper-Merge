using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

public class BuffProcessingService
{
    private IReadOnlyList<IBuffable> _allBuffables;
    
    public event Action<Buff> BuffApplied;
    public event Action<Buff> BuffEnded;
    
    [Inject]
    public BuffProcessingService(IReadOnlyList<IBuffable> allBuffables) => _allBuffables = allBuffables;
    
    public async void ApplyBuff<T>(T buff) where T : Buff
    {
        var buffable = _allBuffables.FirstOrDefault(buffable => buffable.BuffableType == typeof(T));

        if (buffable == null)
            throw new InvalidCastException("There is no buffable with type " + typeof(T) + " in the list");
        
        buffable.ApplyBuff(buff);
        BuffApplied?.Invoke(buff);
        Debug.Log("BuffApplied");
        await WaitForBuffEnd(buff.Duration);
        EndBuff(buff, buffable);
        Debug.Log("BuffEnded");
    }
    
    private async UniTask WaitForBuffEnd(float duration) => await UniTask.WaitForSeconds(duration);

    private void EndBuff(Buff buff, IBuffable buffable)
    {
        buffable.EndBuff(buff);
        BuffEnded?.Invoke(buff);
    }
}