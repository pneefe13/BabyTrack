namespace Frontend.Serialization;

public interface ITypedSerializer<T> : ISerializer
{
    public byte[] Serialize(T data);

    public T Deserialize(byte[] serialized);
}
