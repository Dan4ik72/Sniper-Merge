using System.Runtime.CompilerServices;
using UnityEngine;
using VContainer;

public class GameBootstrapper : MonoBehaviour
{
    [Inject] private MergeService _mergeService;

    private void Start()
    {
        _mergeService.Init();
    }

    private void Awake()
    {

    }

    private void Update()
    {
        _mergeService.Update();
    }

    private void OnDisable()
    {
        _mergeService.Disable();
    }
}
