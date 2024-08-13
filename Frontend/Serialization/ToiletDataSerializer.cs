using Frontend.MVVM.Models.SaveData;

namespace Frontend.Serialization;
public class ToiletDataSerializer : ITypedSerializer<ToiletData>
{
    public bool CanSerialize(Type type)
    {
        return type == typeof(ToiletData);
    }

    public ToiletData Deserialize(byte[] serialized)
    {
        //TODO
        return new ToiletData();
    }

    public object Deserialize(byte[] serialized, Type type)
    {
        if (type != ProvideType())
            throw new InvalidOperationException($"{this} cannot deserialize to '{type}'!");

        return Deserialize(serialized);
    }

    public Type ProvideType()
    {
        return typeof(ToiletData);
    }

    public byte[] Serialize(ToiletData data)
    {
        //TODO
        return [];
    }

    public byte[] Serialize(object data)
    {
        if (data is ToiletData toiletData)
            return Serialize(toiletData);

        throw new InvalidOperationException($"{this} cannot serialize '{data.GetType()}';");
    }
}
