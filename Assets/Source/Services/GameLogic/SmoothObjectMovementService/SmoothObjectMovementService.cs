using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public static class SmoothObjectMovementService
{
    private static Dictionary<Transform, CancellationTokenSource> _currentMoving = new();
    
    public static async UniTask MoveAsync(Transform obj, Vector3 targetPosition, float speed)
    {
        if (_currentMoving.ContainsKey(obj))
        {
            Debug.LogWarning(obj.name + " object is already moving");
            return;
        }
        
        var tokenSource = new CancellationTokenSource();
        
        await MoveSmooth(obj, targetPosition, speed, tokenSource.Token);
    }

    private static async UniTask MoveSmooth(Transform obj, Vector3 position, float speed, CancellationToken token)
    {
        while ((Vector3.Distance(obj.transform.position, position) > 0.1f) && token.IsCancellationRequested == false)
        {
            Debug.Log("Moving");
            
            obj.position = Vector3.MoveTowards(obj.transform.position, position, speed);

            await UniTask.Yield();
        }
        
        _currentMoving.Remove(obj);
    }

    private static bool TryStopMoving(Transform currentMoving)
    {
        if (_currentMoving.ContainsKey(currentMoving) == false)
            return false;
        
        _currentMoving[currentMoving].Cancel();
        _currentMoving.Remove(currentMoving);
        
        return true;
    }
}