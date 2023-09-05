using UnityEngine;

internal class JsonUtilityConverter : IDataToJsonConverter
{
    public string Convert<T>(object data)
    {
        return JsonUtility.ToJson(data);
    }

    public T Deconvert<T>(string json)
    {
        return JsonUtility.FromJson<T>(json);
    }
}