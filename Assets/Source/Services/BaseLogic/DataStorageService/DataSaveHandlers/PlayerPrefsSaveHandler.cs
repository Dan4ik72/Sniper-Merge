using UnityEngine;

internal class PlayerPrefsSaveHandler : IDataSaveHandler
{
    public void SaveString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
        PlayerPrefs.Save();
    }
    
    public string LoadString(string key)
    {
        return PlayerPrefs.GetString(key);
    }

    public bool HasKey(string key)
    {
        return PlayerPrefs.HasKey(key);
    }
}