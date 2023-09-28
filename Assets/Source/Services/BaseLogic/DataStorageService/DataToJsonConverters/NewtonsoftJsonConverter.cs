using Newtonsoft.Json;

public class NewtonsoftJsonConverter : IDataToJsonConverter
{
    public string Convert<T>(object data)
    {
        return JsonConvert.SerializeObject(data, typeof(T), new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        });
    }

    public T Deconvert<T>(string json)
    {
        return JsonConvert.DeserializeObject<T>(json);
    }
}