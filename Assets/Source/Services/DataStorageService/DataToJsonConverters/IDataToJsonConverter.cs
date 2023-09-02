internal interface IDataToJsonConverter
{
    public string Convert<T>(object data);

    public T Deconvert<T>(string json);
}