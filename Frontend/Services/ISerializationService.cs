namespace Frontend.Services;

public interface ISerializationService
{
    public void Serialize(object data);

    public object Deserialize(string serialized, Type targetType);
}
