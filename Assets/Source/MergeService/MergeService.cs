using UnityEngine;
using VContainer;

public class MergeService
{
    private IMergeObjectDragHandler _dragHandler;
    private IMergeHandler _mergeHandler;
    private MergeGrid _mergeGrid;
    //temporary code
    private BulletInfoFactory _bulletInfoFactory;

    [Inject]
    internal MergeService(IMergeObjectDragHandler dragHandler, IMergeHandler mergeHandler, MergeGrid mergeGrid, BulletInfoFactory bulletFactory)
    {
        _dragHandler = dragHandler;
        _mergeGrid = mergeGrid;
        _mergeHandler = mergeHandler;
        _bulletInfoFactory = bulletFactory;
    }

    public void Init()
    {
        _dragHandler.ItemReleased += _mergeHandler.OnItemReleased;

        _mergeGrid.CreateGrid();
        
        CreateTestBullet(new Vector3(10, 15, 20), 0);
        CreateTestBullet(new Vector3(-10, -15,-20), 1);
    }

    //temporary code
    private void CreateTestBullet(Vector3 position, int cellIndex)
    {
        var bullet = _bulletInfoFactory.CreateByType(MergeItemType.Level1Item, position);

        var cells = _mergeGrid.GetOrderedCellsByPosition(bullet.View.transform.position);

        bullet.View.transform.position = cells[cellIndex].transform.position;
        _mergeGrid.SetMergeItemToCell(cells[cellIndex], bullet);
    }

    public void Update()
    {
        _dragHandler.DragItem();
    }

    public void Disable()
    {
        _mergeGrid.ClearGrid();
    }
}