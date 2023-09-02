using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CollisionDetectionView : MonoBehaviour
{
    public event Action<Collider> TriggerEntered;
    public event Action<Collider> TriggerExited;

    public event Action<Collision> CollisionEntered;
    public event Action<Collision> CollisionExited;

    public void OnObstacleBroke() => Destroy(gameObject);

    private void OnTriggerEnter(Collider other)
    {
        TriggerEntered?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        TriggerExited?.Invoke(other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        CollisionEntered?.Invoke(collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        CollisionExited?.Invoke(collision);
    }
}