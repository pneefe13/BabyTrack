using Frontend.MVVM.Models.SaveData;

namespace Frontend.Serialization;
public class SleepDataSerializer : ITypedSerializer<SleepData>
{
    public bool CanSerialize(Type type)
    {
        return type == typeof(SleepData);
    }

    public SleepData Deserialize(string serialized)
    {
        //TODO
        return new SleepData();
    }

    public object Deserialize(string serialized, Type type)
    {
        if (type != ProvideType())
            throw new InvalidOperationException($"{this} cannot deserialize to '{type}'!");

        return Deserialize(serialized);
    }

    public Type ProvideType()
    {
        return typeof(SleepData);
    }

    public string Serialize(SleepData data)
    {
        //TODO
        return string.Empty;
    }

    public string Serialize(object data)
    {
        if (data is SleepData sleepData)
            return Serialize(sleepData);

        throw new InvalidOperationException($"{this} cannot serialize '{data.GetType()}';");
    }
}
