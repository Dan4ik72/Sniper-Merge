using UnityEngine;
using VContainer;

internal class SpikeObstacleFactory : IObstacleFactory
{
    private SpikeObstacleConfig _defalutConfig;

    [Inject]
    internal SpikeObstacleFactory(SpikeObstacleConfig config)
    {
        _defalutConfig = config;
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
        return new SpikeObstacleModel(data.Config.Damage, data.Config.ObstacleDurability,
            data.Config.DurabilityDecreasingStep, data.Config.DamageTickRate);
    }

    private CollisionDetectionView CreateView(SpikeObstacleData data)
    {
        return Object.Instantiate(data.Config.ViewPrefab, data.Config.Position, data.Config.Rotation);
    }

    private SpikeObstacleData CreateData()
    {
        //temporary code
        return new SpikeObstacleData(_defalutConfig);
        //temporary code
    }
}
