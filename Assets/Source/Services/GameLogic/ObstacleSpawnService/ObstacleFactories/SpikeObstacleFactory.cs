using UnityEngine;
using VContainer;

internal class SpikeObstacleFactory : IObstacleFactory
{
    private DataStorageService _dataStorageService;
    
    [Inject]
    internal SpikeObstacleFactory(DataStorageService dataStorageService)
    {
        _dataStorageService = dataStorageService;
    }

    public IObstacle Create()
    {
        var data = CreateData();
        var model = CreateModel(data);
        var view = CreateView(data);

        return new SpikeObstacle(view, model);
    }

    private SpikeObstacleModel CreateModel(SpikeObstacleData data)
    {
        if (data == null)
            return null;
        
        return new SpikeObstacleModel(data.Damage, data.ObstacleDurability,
            data.DurabilityDecreasingStep, data.DamageTickRate);
    }

    private CollisionDetectionView CreateView(SpikeObstacleData data)
    {
        if (data == null)
            return null;
        
        return Object.Instantiate(Resources.Load<CollisionDetectionView>(data.ViewPrefabPath), data.Position, data.Rotation);
    }

    private SpikeObstacleData CreateData()
    {
        if (_dataStorageService.TryGetData(out SpikeObstacleData data))
            return data;

        return null;
    }
}
