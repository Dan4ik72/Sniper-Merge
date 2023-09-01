using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class DataStorageService
{
    private const string DataKey = "DataStorageKey";

    private Dictionary<Type, object> _data;

    private IDataToJsonConverter _jsonConverter;
    private IDataSaveHandler _dataSaveHandler;

    [Inject]
    internal DataStorageService(IDataToJsonConverter jsonConverter, IDataSaveHandler dataSaveHandler)
    {
        _jsonConverter = jsonConverter;
        _dataSaveHandler = dataSaveHandler;
    }

    public Dictionary<Type, object> Data => _data;

    public void Init()
    {   
        if(_data != null)
            return;

        InitInternal();
    }

    public void SaveData<T>(object data) where T : IData
    {
        _data.Add(typeof(T), data);

        var json = _jsonConverter.Convert<T>(_data);

        Debug.Log(json);

        _dataSaveHandler.SaveString(DataKey, json);
    }

    public bool TryGetData<T>(out object data) where T : IData
    {
        return _data.TryGetValue(typeof(T), out data);
    }

    private void InitInternal()
    {
        _data = new Dictionary<Type, object>();

        if(_dataSaveHandler.HasKey(DataKey) == false)
            return; 

        _data = _jsonConverter.Deconvert<Dictionary<Type, object>>(_dataSaveHandler.LoadString(DataKey));
    }
}