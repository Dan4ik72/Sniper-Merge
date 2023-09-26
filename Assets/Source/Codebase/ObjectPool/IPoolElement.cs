using UnityEngine;

public interface IPoolElement
{
    public int Level { get; }

    public bool IsActive { get; }

    public Transform GetTransform();
}
