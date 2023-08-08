using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;

internal class ObjectPool
{
    private List<GameObject> _pool = new();

    [Inject]
    public ObjectPool(GameObject prefab, Transform spawnPoint, int capacity)
    {
        for (int i = 0; i < capacity; i++)
        {
            GameObject spawned = Object.Instantiate(prefab, Vector3.zero, Quaternion.identity, spawnPoint);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);
        return result != null;
    }

    protected void Reset()
    {
        foreach (var item in _pool)
            Object.Destroy(item.gameObject);

        _pool.Clear();  
    }
}
