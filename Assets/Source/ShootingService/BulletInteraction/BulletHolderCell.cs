using UnityEngine;

internal class BulletHolderCell : MonoBehaviour, ICell
{
    public int Heigh => 1;
    public int Width => 1;

    public Transform GetTransform()
    {
        return transform;
    }
}