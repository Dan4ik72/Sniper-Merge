using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;

internal class ObjectPool<T> where T : MonoBehaviour
{
    private List<T> _objects = new();
    private List<Vector3> _disabledPositions = new();

    private int _levelObject = -1;
    private Vector3 _defaultDisabledPosition = new Vector3(0, -100, 0);
    private Vector3 _offsetPostion = new Vector3(0, -1, 0);

    public void AddObject(T prefab, int level = -1, bool isActiveByDefault = false)
    {
        Vector3 disabledPosition = _defaultDisabledPosition;

        if (level >= 0)
        {
            disabledPosition = _defaultDisabledPosition + _offsetPostion * level;

            if (CanAddNewPosition(level))
            {
                _disabledPositions.Add(disabledPosition);
            }
        }

        if (isActiveByDefault == false)
            prefab.transform.position = disabledPosition;

        _objects.Add(prefab);
    }

    public bool TryGetAvailableObject(out T available, int level = -1)
    {
        if (level == -1)
            available = _objects.FirstOrDefault(p => p.transform.position == _defaultDisabledPosition);
        else
            available = _objects.FirstOrDefault(p => p.transform.position == _disabledPositions[level]);

        return available != null;
    }

    public void ReturnToPool(T obj, int level = -1)
    {
        if (_objects.Contains(obj) == false)
        {
            Debug.LogWarning("There is no such an object in the pool " + obj.gameObject.name);
            return;
        }

        if (level == -1)
            obj.transform.position = _defaultDisabledPosition;
        else
            obj.transform.position = _disabledPositions[level];
    }

    private bool CanAddNewPosition(int level)
    {
        if (_levelObject < level)
        {
            _levelObject++;
            return true;
        }

        return false;
    }
}
