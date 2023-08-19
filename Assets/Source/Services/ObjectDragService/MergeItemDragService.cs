using UnityEngine;
using VContainer;

public class MergeItemDragService
{
    private IObjectDragHandler _dragHandler;

    private MergeService _mergeService;
    private ShootingService _shootingService;

    private InputService _inputService;

    [Inject]
    internal MergeItemDragService(IObjectDragHandler objectDragHandler, InputService inputService, MergeService mergeService, ShootingService shootingService)
    {
        _dragHandler = objectDragHandler;
        _inputService = inputService;
        _mergeService = mergeService;
        _shootingService = shootingService;
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

    private void OnObjectGrabbed(MergeItem mergeItem)
    {
        if (Vector3.Distance(_mergeService.GetClosestMergeGridCell(mergeItem.View.transform.position).position, 
                mergeItem.View.transform.position ) <= 1.7f)
        {
            _mergeService.ClearGridCell(mergeItem);
            return;
        }

        if (Vector3.Distance(_shootingService.BulletHolderPosition, mergeItem.View.transform.position) <= 1.7f)
        {
            _shootingService.ClearBulletPlace();
            return;
        }
    }

    private void OnObjectReleased(MergeItem mergeItem)
    {
        if (Vector3.Distance(_mergeService.GetClosestMergeGridCell(mergeItem.View.transform.position).position,
                mergeItem.View.transform.position) <= 1.7f)
        {
            _mergeService.OnItemReleasedOnGrid(mergeItem);
            return;
        }
        
        if (Vector3.Distance(_shootingService.BulletHolderPosition, mergeItem.View.transform.position) <= 1.7f)
        {
            if (_shootingService.TryPlaceBulletToBulletHolder(mergeItem))
                return;
        }

        _mergeService.TryPlaceMergeItemToAvailableCell(mergeItem);
    }
}
