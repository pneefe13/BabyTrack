using Frontend.MVVM.Models.SaveData;
using System.IO;
using System.Text;

namespace Frontend.Serialization;

public class MainDataSerializer : ITypedSerializer<MainData>
{
    public MainDataSerializer(ITypedSerializer<ToiletData> toiletDataSerializer,
                              ITypedSerializer<SleepData> sleepDataSerializer,
                              ITypedSerializer<BreastFeedData> breastFeedDataSerializer)
    {
        _toiletDataSerializer = toiletDataSerializer;
        _sleepDataSerializer = sleepDataSerializer;
        _breastFeedDataSerializer = breastFeedDataSerializer;
    }

    public MainData Deserialize(string serialized)
    {
        var bytes = Encoding.UTF8.GetBytes(serialized);
        using var ms = new MemoryStream(bytes);
        var reader = new BinaryReader(ms);
        var header = reader.ReadInt32();
        if (header != SerializationHeader)
        {
            //TODO: handle wrong file type
        }

        var version = reader.ReadInt32();
        if (version != Version)
        {
            //TODO handle wrong version
        }

        var serializedToiletData = reader.ReadString();
        var toiletData = _toiletDataSerializer.Deserialize(serializedToiletData);
        var serializedBreastFeedData = reader.ReadString();
        var breastFeedData = _breastFeedDataSerializer.Deserialize(serializedBreastFeedData);
        var serializedSleepData = reader.ReadString();
        var sleepData = _sleepDataSerializer.Deserialize(serializedSleepData);
        return new MainData(breastFeedData, toiletData, sleepData);
    }

    public string Serialize(MainData data)
    {
        using var ms = new MemoryStream();
        var writer = new BinaryWriter(ms);
        writer.Write(SerializationHeader);
        writer.Write(Version);
        var serializedToiletData = _toiletDataSerializer.Serialize(data.ToiletData);
        writer.Write(serializedToiletData);
        var serializedBreastFeedData = _breastFeedDataSerializer.Serialize(data.BreastFeedData);
        writer.Write(serializedBreastFeedData);
        var serializedSleepData = _sleepDataSerializer.Serialize(data.SleepData);
        writer.Write(serializedSleepData);

        ms.Position = 0;
        var reader = new StreamReader(ms, Encoding.UTF8);
        var serialized = reader.ReadToEnd();
        return serialized;
    }

    public bool CanSerialize(Type type)
    {
        return type == typeof(MainData);
    }

    public string Serialize(object data)
    {
        if (data is MainData mainData)
            return Serialize(mainData);

        throw new InvalidOperationException($"{this} cannot serialize '{data.GetType()}';");
    }

    public Type ProvideType()
    {
        return typeof(MainData);
    }

    public object Deserialize(string serialized, Type type)
    {
        if (type != ProvideType())
            throw new InvalidOperationException($"{this} cannot deserialize to '{type}'!");

        return Deserialize(serialized);
    }

    private ITypedSerializer<ToiletData> _toiletDataSerializer = null!;
    private ITypedSerializer<BreastFeedData> _breastFeedDataSerializer = null!;
    private ITypedSerializer<SleepData> _sleepDataSerializer = null!;

    private const int SerializationHeader = 331012693; //13BADA55 ;)
    private const int Version = 1;
}
