using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;

internal class ObjectPool<T> where T : MonoBehaviour
{
    private List<T> _objects = new();
    private List<T> _prefabs = new();
    private List<Vector3> _disabledPositions = new();

    private Vector3 _defaultDisabledPosition = new Vector3(0, -100, 0);
    private Vector3 _offsetPostion = new Vector3(0, -1, 0);

    [Inject]
    public ObjectPool(List<T> prefabs) => _prefabs = prefabs;

    public void CreatePool(Transform parent, int capacity, bool isActiveByDefault = false)
    {
        for (int i = 0; i < _prefabs.Count; i++)
        {
            Vector3 disabledPosition = _defaultDisabledPosition + _offsetPostion * i;
            _disabledPositions.Add(disabledPosition);

            for (int j = 0; j < capacity; j++)
            {
                var spawned = Object.Instantiate(_prefabs[i], Vector3.zero, Quaternion.identity, parent);
                _disabledPositions.Add(disabledPosition);

                if (isActiveByDefault == false)
                {
                    spawned.transform.position = disabledPosition;
                }

                _objects.Add(spawned);
            }
        }
    }

    public bool TryGetAvailableObject(out T available, int level = -1)
    {
        if (level == -1)
            available = _objects.FirstOrDefault(p => p.transform.position == _defaultDisabledPosition);
        else
        available = _objects.FirstOrDefault(p => p.transform.position == _disabledPositions[level]);

        return available != null;
    }

    public void ReturnToPool(T obj)
    {
        if (_objects.Contains(obj) == false)
        {
            Debug.LogWarning("There is no such an object in the pool " + obj.gameObject.name);
            return;
        }

        obj.transform.position = _defaultDisabledPosition;
    }
}
