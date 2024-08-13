using DataStructures.SaveData;

namespace DataStructures.Serialization;
public class BreastFeedDataSerializer : ITypedSerializer<BreastFeedData>
{
    public bool CanSerialize(Type type)
    {
        return type == typeof(BreastFeedData);
    }

    public BreastFeedData Deserialize(string serialized)
    {
        //TODO
        return new BreastFeedData();
    }

    public object Deserialize(string serialized, Type type)
    {
        if (type != ProvideType())
            throw new InvalidOperationException($"{this} cannot deserialize to '{type}'!");

        return Deserialize(serialized);
    }

    public Type ProvideType()
    {
        return typeof(BreastFeedData);
    }

    public string Serialize(BreastFeedData data)
    {
        //TODO
        return string.Empty;
    }

    public string Serialize(object data)
    {
        if (data is BreastFeedData breastFeedData)
            return Serialize(breastFeedData);

        throw new InvalidOperationException($"{this} cannot serialize '{data.GetType()}';");
    }
}
