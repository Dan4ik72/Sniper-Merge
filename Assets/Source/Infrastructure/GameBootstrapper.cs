using System.Runtime.CompilerServices;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameBootstrapper : MonoBehaviour
{
    [Inject] private MergeService _mergeService;

    private void Awake()
    {
        _mergeService.Init();
    }
    
}
