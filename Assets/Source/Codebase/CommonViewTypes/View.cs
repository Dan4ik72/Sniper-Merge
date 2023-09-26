using UnityEngine;

public class View : MonoBehaviour, IPoolElement
{
    public int Level { get; private set; } = 1;
    public bool IsActive { get; private set; } = false;

    public void Init(int level, bool isAliveByDefault)
    {
        Level = level;
        IsActive = isAliveByDefault;
    }

    public void SetActive(bool isActive) => IsActive = isActive;
    
    public Transform GetTransform() => transform;
}
