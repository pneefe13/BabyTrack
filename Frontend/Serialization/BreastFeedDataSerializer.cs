using Frontend.MVVM.Models.SaveData;

namespace Frontend.Serialization;

public class BreastFeedDataSerializer : ITypedSerializer<BreastFeedData>
{
    public bool CanSerialize(Type type)
    {
        return type == typeof(BreastFeedData);
    }

    public BreastFeedData Deserialize(byte[] serialized)
    {
        //TODO
        return new BreastFeedData();
    }

    public object Deserialize(byte[] serialized, Type type)
    {
        if (type != ProvideType())
            throw new InvalidOperationException($"{this} cannot deserialize to '{type}'!");

        return Deserialize(serialized);
    }

    public Type ProvideType()
    {
        return typeof(BreastFeedData);
    }

    public byte[] Serialize(BreastFeedData data)
    {
        //TODO
        return [];
    }

    public byte[] Serialize(object data)
    {
        if (data is BreastFeedData breastFeedData)
            return Serialize(breastFeedData);

        throw new InvalidOperationException($"{this} cannot serialize '{data.GetType()}';");
    }
}
