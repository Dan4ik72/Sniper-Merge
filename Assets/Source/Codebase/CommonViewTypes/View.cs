using UnityEngine;

public class View : MonoBehaviour, IPoolElement
{
    public int Level { get; private set; } = 1;
    public bool IsAlive { get; private set; } = false;

    public void Init(int level, bool isAliveByDefault)
    {
        Level = level;
        IsAlive = isAliveByDefault;
    }

    public void SetAlive(bool isAlive) => IsAlive = isAlive;
    
    public Transform GetTransform() => transform;
}
