using UnityEngine;

internal class WallObstacleFactory : IObstacleFactory
{
    private DataStorageService _dataStorageService;
    
    internal WallObstacleFactory(DataStorageService dataStorageService)
    {
        _dataStorageService = dataStorageService;
    }

    public IObstacle Create()
    {
        var data = CreateData();

        IObstacle wallObstacle = new WallObstacle(CreateView(data), CreateModel(data));

        return wallObstacle;
    }

    private WallObstacleModel CreateModel(WallObstacleData data)
    {
        if (data == null)
            return null;
        
        return new WallObstacleModel(data.Durability);
    }

    private DamagableView CreateView(WallObstacleData data)
    {
        if (data == null)
            return null;
        
        var created = Object.Instantiate(Resources.Load<DamagableView>(data.PrefabPath), data.Position, Quaternion.identity);

        created.transform.eulerAngles += new Vector3(data.Rotation.x, data.Rotation.y, data.Rotation.z);
        
        return created;
    }

    private WallObstacleData CreateData()
    {
        if (_dataStorageService.TryGetData(out WallObstacleData data))
            return data;
        
        return null;
    }
}