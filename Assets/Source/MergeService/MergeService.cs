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

        CreateTestBullet(new Vector3(10, 15, 20), "0", 0);
        CreateTestBullet(new Vector3(10, 15, 20), "1", 1);
        CreateTestBullet(new Vector3(10, 15, 20), "2", 2);
        CreateTestBullet(new Vector3(10, 15, 20), "3", 3);
    }

    //temporary code
    private void CreateTestBullet(Vector3 position, string name, int cum)
    {
        var bullet = _bulletInfoFactory.CreateByType(MergeItemType.Level1Item, position);

        bullet.View.name = name;

        var cells = _mergeGrid.GetOrderedCellsByPosition(bullet.View.transform.position);

        bullet.View.transform.position = cells[cum].transform.position;
        _mergeGrid.SetMergeItemToCell(cells[cum], bullet);
    }

    public void Update()
    {
        _dragHandler.DragItem();
    }

    public void Disable()
    {
        //_mergeGrid.ClearGrid();
        _dragHandler.ItemReleased -= _mergeHandler.OnItemReleased;
    }
}