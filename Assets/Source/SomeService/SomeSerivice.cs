using UnityEngine;
using VContainer;

public class SomeSerivice
{
    private Controller _controller;
    private MergeService _mergeService;

    [Inject]
    internal SomeSerivice(Controller controller, MergeService mergeService)
    {
        _controller = controller;
        _mergeService = mergeService;
    }

    public void Init()
    {
        Debug.Log(_mergeService == null);
    }
}
