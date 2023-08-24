using UnityEngine;

public class BulletView : MonoBehaviour, IPoolElement
{
    public int Level { get; private set; }
    public bool IsAlive { get; private set; }

    public void Init(int level) => Level = level;

    public void SetAlive(bool isAlive) => IsAlive = isAlive;

    public Transform GetTransform() => transform;
}
