using System.Runtime.CompilerServices;
using UnityEngine;
using VContainer;

public class GameBootstrapper : MonoBehaviour
{
    [Inject] private MergeService _mergeService;
    [Inject] private ShootingService _shootingService;

    private void Start()
    {
        _mergeService.Init();
        _shootingService.Init();
    }

    private void Awake()
    {

    }

    private void Update()
    {
        _mergeService.Update();
        _shootingService.Update(Time.deltaTime);
    }

    private void OnDisable()
    {
        _mergeService.Disable();
        _shootingService.Disable();
    }
}
