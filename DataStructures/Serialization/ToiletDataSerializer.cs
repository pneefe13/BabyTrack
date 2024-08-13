using DataStructures.SaveData;

namespace DataStructures.Serialization;
public class ToiletDataSerializer : ITypedSerializer<ToiletData>
{
    public bool CanSerialize(Type type)
    {
        return type == typeof(ToiletData);
    }

    public ToiletData Deserialize(string serialized)
    {
        //TODO
        return new ToiletData();
    }

    public object Deserialize(string serialized, Type type)
    {
        if (type != ProvideType())
            throw new InvalidOperationException($"{this} cannot deserialize to '{type}'!");

        return Deserialize(serialized);
    }

    public Type ProvideType()
    {
        return typeof(ToiletData);
    }

    public string Serialize(ToiletData data)
    {
        //TODO
        return string.Empty;
    }

    public string Serialize(object data)
    {
        if (data is ToiletData toiletData)
            return Serialize(toiletData);

        throw new InvalidOperationException($"{this} cannot serialize '{data.GetType()}';");
    }
}
