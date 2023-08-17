using UnityEngine;

public interface ICell
{
    public int Heigh { get; }
    public int Width { get; }

    public Transform GetTransform();
}
