using System.Collections.Generic;
using UnityEngine;
using VContainer;

internal class GridFactory
{
    private readonly ICell _cellPrefab;
    private readonly Transform _parent;

    private readonly Vector2 _capacity = new Vector2(4, 4);

    private List<Transform> _cells;

    private float _cellPositionRandomness = 0;

    [Inject]
    public GridFactory(Transform cellParent, ICell cellPrefab)
    {
        _cellPrefab = cellPrefab;
        _parent = cellParent;

        _cells = new List<Transform>();
    }

    public IReadOnlyList<Transform> Cells => _cells;
    public Vector2 Capacity => _capacity;

    public GridFactory Create()
    {
        for (float currentXPosition = _parent.position.x; currentXPosition <= _capacity.x + _parent.position.x;)
        {
            for (float currentYPosition = _parent.position.z; currentYPosition <= _capacity.y + _parent.position.z;)
            {
                var cellPosition = new Vector3(currentXPosition + Random.Range(-_cellPositionRandomness, _cellPositionRandomness)
                    , _parent.position.y,
                    currentYPosition + Random.Range(-_cellPositionRandomness, _cellPositionRandomness));

                CreateCellTransform(cellPosition);

                currentYPosition += _cellPrefab.Heigh;
            }

            currentXPosition += _cellPrefab.Width;
        }

        return this;
    }

    public void Reset()
    {
        foreach (Transform cell in _cells)
            Object.Destroy(cell.gameObject);
     
        _cells.Clear();
    }

    private Transform CreateCellTransform(Vector3 position)
    {
        var cellPosition = new Vector3(position.x, position.y, position.z);
    
        Transform newCell = Object.Instantiate(_cellPrefab.GetTransform(), cellPosition, Quaternion.identity, _parent);
    
        _cells.Add(newCell);
     
        return newCell;
    }
}