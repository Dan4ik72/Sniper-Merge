using UnityEngine;

internal class WallObstacleFactory : IObstacleFactory
{
    private WallObstacleConfig _defaultConfig;
    
    private DataStorageService _dataStorageService;
    
    internal WallObstacleFactory(WallObstacleConfig defaultConfig, DataStorageService dataStorageService)
    {
        _defaultConfig = defaultConfig;
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
        return new WallObstacleModel(data.Durability);
    }

    private DamagableView CreateView(WallObstacleData data)
    {
         return Object.Instantiate(Resources.Load<DamagableView>(data.PrefabPath), data.Position, data.Rotation);
    }

    private WallObstacleData CreateData()
    {
        if (_dataStorageService.TryGetData(out WallObstacleData data))
            return data;

        var defaultData = new WallObstacleData(_defaultConfig);
        _dataStorageService.SaveData<WallObstacleData>(defaultData);
        
        return defaultData;
    }
}