using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Effect : MonoBehaviour, IPoolElement
{
    private ParticleSystem _particle;

    public int Level { get; private set; }
    public bool IsAlive { get; private set; }

    public event Action<Effect> Finished;

    public Transform GetTransform() => transform;

    public void Init()
    {
        _particle = GetComponent<ParticleSystem>();
        IsAlive = false;
    }

    public async UniTask Active(Vector3 position)
    {
        IsAlive = true;
        transform.position = position;
        _particle.Play();

        await UniTask.WaitForSeconds(2);

        IsAlive = false;
        Finished?.Invoke(this);
    }
}
