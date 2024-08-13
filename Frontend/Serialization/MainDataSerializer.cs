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

    public MainData Deserialize(byte[] serialized)
    {
        using var ms = new MemoryStream(serialized);
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

        var serializedToiletDataLength = reader.ReadInt32();
        var serializedToiletData = reader.ReadBytes(serializedToiletDataLength);
        var toiletData = _toiletDataSerializer.Deserialize(serializedToiletData);

        var serializedBreastFeedDataLength = reader.ReadInt32();
        var serializedBreastFeedData = reader.ReadBytes(serializedBreastFeedDataLength);
        var breastFeedData = _breastFeedDataSerializer.Deserialize(serializedBreastFeedData);

        var serializedSleepDataLength = reader.ReadInt32();
        var serializedSleepData = reader.ReadBytes(serializedSleepDataLength);
        var sleepData = _sleepDataSerializer.Deserialize(serializedSleepData);
        
        return new MainData(breastFeedData, toiletData, sleepData);
    }

    public byte[] Serialize(MainData data)
    {
        using var ms = new MemoryStream();
        var writer = new BinaryWriter(ms);
        writer.Write(SerializationHeader);
        writer.Write(Version);
        var serializedToiletData = _toiletDataSerializer.Serialize(data.ToiletData);
        writer.Write(serializedToiletData.Length);
        writer.Write(serializedToiletData);
        var serializedBreastFeedData = _breastFeedDataSerializer.Serialize(data.BreastFeedData);
        writer.Write(serializedBreastFeedData.Length);
        writer.Write(serializedBreastFeedData);
        var serializedSleepData = _sleepDataSerializer.Serialize(data.SleepData);
        writer.Write(serializedSleepData.Length);
        writer.Write(serializedSleepData);

        return ms.ToArray();
    }

    public bool CanSerialize(Type type)
    {
        return type == typeof(MainData);
    }

    public byte[] Serialize(object data)
    {
        if (data is MainData mainData)
            return Serialize(mainData);

        throw new InvalidOperationException($"{this} cannot serialize '{data.GetType()}';");
    }

    public Type ProvideType()
    {
        return typeof(MainData);
    }

    public object Deserialize(byte[] serialized, Type type)
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
