namespace Frontend.Services;

public interface ISerializationService
{
    public byte[] Serialize(object data);

    public object Deserialize(byte[] serialized, Type targetType);
}
