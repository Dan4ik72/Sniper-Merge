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

        //Debug.Log(key + " " +_dataSaveHandler.HasKey(key));
        
        if (_dataSaveHandler.HasKey(key) == false)
            return false;

        //Debug.Log(key);
        
        var json = _dataSaveHandler.LoadString(key);

        if (json == string.Empty || json == "{}" || json == "{ }")
            return false;

        //Debug.Log(key);
        
        data = _jsonConverter.Deconvert<T>(json);

        return true;
    }
}