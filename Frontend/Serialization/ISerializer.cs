namespace Frontend.Serialization;

public interface ISerializer
{
    public bool CanSerialize(Type type);

    public Type ProvideType();

    public byte[] Serialize(object data);

    public object Deserialize(byte[] serialized, Type type);
}
