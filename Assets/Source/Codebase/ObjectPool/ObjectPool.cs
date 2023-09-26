using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool<T> where T : IPoolElement
{
    private List<T> _objects = new();

    private Vector3 _disabledPosition = new Vector3(0, -100, 0);

    public void AddObject(T obj, bool isActiveByDefault = false)
    {
        if (isActiveByDefault == false)
            obj.GetTransform().position = _disabledPosition;

        _objects.Add(obj);
    }

    public bool TryGetAvailableObject(out T available, int level = 0)
    {
        available = _objects.FirstOrDefault(obj => obj.Level == level && obj.IsActive == false);

        return available != null;
    }

    public void ReturnToPool(T obj)
    {
        if (_objects.Contains(obj) == false)
        {
#if UNITY_EDITOR
            Debug.LogWarning("There is no such an object in the pool " + obj.GetTransform().name);
#endif
            return;
        }

        obj.GetTransform().position = _disabledPosition;
    }
}
