namespace DataStructures.Serialization;

public interface ITypedSerializer<T> : ISerializer
{
    public string Serialize(T data);

    public T Deserialize(string serialized);
}
