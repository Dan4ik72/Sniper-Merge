using UnityEngine;

public class BulletView : MonoBehaviour, IPoolElement
{
    public int Level { get; private set; }
    public bool IsActive { get; private set; }

    public void Init(int level) => Level = level;

    public void SetActive(bool isActive) => IsActive = isActive;

    public Transform GetTransform() => transform;
}
