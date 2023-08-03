using System.Runtime.CompilerServices;
using UnityEngine;
using VContainer;

public class GameBootstrapper : MonoBehaviour
{
    [Inject] private MergeService _mergeService;
    [Inject] private SomeSerivice _someSerivice;

    private void Start()
    {
        _someSerivice.Init();
        _mergeService.Init();
    }
}
