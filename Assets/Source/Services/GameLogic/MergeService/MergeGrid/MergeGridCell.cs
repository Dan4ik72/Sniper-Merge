using UnityEngine;

internal class MergeGridCell : MonoBehaviour, ICell
{
    public int Heigh { get; } = 2;
    public int Width { get; } = 2;

    public Transform GetTransform() => transform;
}
