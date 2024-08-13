namespace DataStructures.Serialization;

public interface ISerializer
{
    public bool CanSerialize(Type type);

    public Type ProvideType();

    public string Serialize(object data);

    public object Deserialize(string serialized, Type type);
}
