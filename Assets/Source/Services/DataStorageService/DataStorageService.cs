using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class DataStorageService
{
    private IDataToJsonConverter _jsonConverter;
    private IDataSaveHandler _dataSaveHandler;

    [Inject]
    internal DataStorageService(IDataToJsonConverter jsonConverter, IDataSaveHandler dataSaveHandler)
    {
        _jsonConverter = jsonConverter;
        _dataSaveHandler = dataSaveHandler;
    }
    
    public void SaveData<T>(object data) where T : IData
    {
        var json = _jsonConverter.Convert<T>(data);
        
        _dataSaveHandler.SaveString(nameof(T), json);
    }

    public bool TryGetData<T>(out T data) where T : IData
    {
        data = default;

        if (_dataSaveHandler.HasKey(nameof(T)) == false)
            return false;

        string json = _dataSaveHandler.LoadString(nameof(T));

        data = _jsonConverter.Deconvert<T>(json);

        return true;
    }
}