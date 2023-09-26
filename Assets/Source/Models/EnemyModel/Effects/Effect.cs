using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Effect : MonoBehaviour, IPoolElement
{
    private ParticleSystem _particle;

    public int Level { get; private set; }
    public bool IsActive { get; private set; }

    public event Action<Effect> Finished;

    public Transform GetTransform() => transform;

    public void Init()
    {
        _particle = GetComponent<ParticleSystem>();
        IsActive = false;
    }

    public async UniTask Active(Vector3 position)
    {
        IsActive = true;
        transform.position = position;
        _particle.Play();

        await UniTask.WaitForSeconds(2);

        IsActive = false;
        Finished?.Invoke(this);
    }
}
