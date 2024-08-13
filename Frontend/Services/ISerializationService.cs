namespace Frontend.Services;

public interface ISerializationService
{
    public string Serialize(object data);

    public object Deserialize(string serialized, Type targetType);
}
