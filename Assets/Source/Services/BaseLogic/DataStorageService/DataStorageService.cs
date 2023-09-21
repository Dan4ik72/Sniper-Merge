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

    public void RemoveSaveData(string key) => _dataSaveHandler.RemoveKey(key);

    public void RemoveData<T>() where T : IData => _dataSaveHandler.RemoveKey(typeof(T).ToString());

    public void SaveData<T>(object data) where T : IData
    {
        var json = _jsonConverter.Convert<T>(data);
        
        _dataSaveHandler.SaveString(typeof(T).ToString(), json);
    }

    public void SaveData<T>(string key, object data)
    {
        var json = _jsonConverter.Convert<T>(data);

        _dataSaveHandler.SaveString(key, json);
    }
    
    public bool TryGetData<T>(out T data) where T : IData
    {
        data = default;

        string name = typeof(T).ToString();

        if (_dataSaveHandler.HasKey(name) == false)
            return false;

        var json = _dataSaveHandler.LoadString(name);
        
        if (json == string.Empty || json == "{}" || json == "{ }")
            return false;
        
        data = _jsonConverter.Deconvert<T>(json);

        return true;
    }

    public bool TryGetData<T>(string key, out T data)
    {
        data = default;

        if (_dataSaveHandler.HasKey(key) == false)
            return false;

        var json = _dataSaveHandler.LoadString(key);

        if (json == string.Empty || json == "{}" || json == "{ }")
            return false;

        data = _jsonConverter.Deconvert<T>(json);

        return true;
    }
}