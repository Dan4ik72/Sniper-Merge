using System;
using System.Collections.Generic;

public class DataStorageService
{
    private Dictionary<Type, object> _data;

    private DataSaver _saver;

    public void Init()
    {
        if(_data != null)
            return;

        InitInternal();
    }

    public void SaveData<T>(object data) where T : IData
    {
        _data.Add(typeof(T), data);
        _saver.Save(_data);
    }

    public bool TryGetData<T>(out object data) where T : IData
    {
        return _data.TryGetValue(typeof(T), out data);
    }

    private void InitInternal()
    {
        _data = new Dictionary<Type, object>();

        _data = _saver.Load();
    }
}

internal class DataSaver
{
    public Dictionary<Type, object> Load()
    {
        return new();
    }

    public void Save(Dictionary<Type, object> data)
    {
        //saving to json
    }
}