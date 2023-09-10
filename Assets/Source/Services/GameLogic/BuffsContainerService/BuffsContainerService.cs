using System.Collections.Generic;
using System.Linq;
using VContainer;

public class BuffsContainerService
{
    private IReadOnlyList<BuffConfig> _allDefaultBuffConfigs;

    private DataStorageService _dataStorageService;
    
    [Inject]
    public BuffsContainerService(IReadOnlyList<BuffConfig> allDefaultBuffConfigs, DataStorageService dataStorageService)
    {
        _allDefaultBuffConfigs = allDefaultBuffConfigs;
        _dataStorageService = dataStorageService;
    }
    
    public T GetBuff<T>() where T : Buff
    {
        if (_dataStorageService.TryGetData(out T data))
            return data;

        var defaultBuffConfig = _allDefaultBuffConfigs.FirstOrDefault(buffConfig => buffConfig.GetBuff().GetType() == typeof(T));

        if (defaultBuffConfig == null)
            throw new System.NullReferenceException("There is no such registered default buff config with type " + typeof(T));

        return (T)defaultBuffConfig.GetBuff();
    }
}