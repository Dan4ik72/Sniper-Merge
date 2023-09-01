using Unity.Plastic.Newtonsoft.Json;

public class NewtonsoftJsonConverter : IDataToJsonConverter
{
    public string Convert<T>(object data)
    {
        return JsonConvert.SerializeObject(data, typeof(T), new JsonSerializerSettings{ TypeNameHandling = TypeNameHandling.Auto});
    }

    public T Deconvert<T>(string json)
    {
        return JsonConvert.DeserializeObject<T>(json);
    }
}