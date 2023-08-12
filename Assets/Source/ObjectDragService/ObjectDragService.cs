using System;

public class ObjectDragService
{
    private IObjectDragHandler _dragHandler;

    private InputService _inputService;

    public event Action<MergeItem> ObjectReleased;
    public event Action<MergeItem> ObjectGrabbed;

    internal ObjectDragService(IObjectDragHandler objectDragHandler, InputService inputService)
    {
        _dragHandler = objectDragHandler;
        _inputService = inputService;
    }

    public void Init()
    {
        _inputService.InputHandler.Pressed += _dragHandler.GrabItem;
        _inputService.InputHandler.Released += _dragHandler.ReleaseItem;

        _dragHandler.ItemGrabbed += OnObjectGrabbed;
        _dragHandler.ItemReleased += OnObjectReleased;
    }

    public void Update()
    {
        _dragHandler.DragItem();
    }

    public void Disable()
    {
        _dragHandler.ItemGrabbed -= OnObjectGrabbed;
        _dragHandler.ItemReleased -= OnObjectReleased;

        _inputService.InputHandler.Pressed -= _dragHandler.ReleaseItem;
        _inputService.InputHandler.Released -= _dragHandler.ReleaseItem;
    }

    private void OnObjectGrabbed(MergeItem mergeItem) => ObjectGrabbed?.Invoke(mergeItem);

    private void OnObjectReleased(MergeItem mergeObject) => ObjectReleased?.Invoke(mergeObject);
    
}
