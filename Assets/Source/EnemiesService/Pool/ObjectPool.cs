using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;

internal class ObjectPool<T> where T : MonoBehaviour
{
    private List<T> _objects = new();
    private T _prefab;

    private Vector3 _disabledPosition = new Vector3(0, -100, 0);

    [Inject]
    public ObjectPool(T prefab) => _prefab = prefab;

    public void CreatePool(Transform parent, int capacity, bool isActiveByDefault = false)
    {
        for (int i = 0; i < capacity; i++)
        {
            var spawned = Object.Instantiate(_prefab, Vector3.zero, Quaternion.identity, parent);
            
            if (isActiveByDefault == false)
            {
                spawned.transform.position = _disabledPosition;
            }

            _objects.Add(spawned);
        }
    }

    public bool TryGetAvailableObject(out T available)
    {
        available = _objects.FirstOrDefault(p => p.transform.position == _disabledPosition);
        return available != null;
    }

    public void ReturnToPool(T obj)
    {
        if (_objects.Contains(obj) == false)
        {
            Debug.LogWarning("There is no such an object in the pool " + obj.gameObject.name);
            return;
        }

        obj.transform.position = _disabledPosition;
    }
}
