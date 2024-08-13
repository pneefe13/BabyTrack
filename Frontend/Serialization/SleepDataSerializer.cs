using Frontend.MVVM.Models.SaveData;
using System.IO;
using System.Text;

namespace Frontend.Serialization;
public class SleepDataSerializer : ITypedSerializer<SleepData>
{
    public bool CanSerialize(Type type)
    {
        return type == typeof(SleepData);
    }

    public SleepData Deserialize(byte[] serialized)
    {
        using var ms = new MemoryStream(serialized);
        var reader = new BinaryReader(ms);

        var daySleepInfos = new List<DaySleepInfo>();

        var infoCount = reader.ReadInt32();
        for (int i = 0; i < infoCount; i++)
        {
            var dayTicks = reader.ReadInt64();
            var day = new DateTime(dayTicks, DateTimeKind.Utc);
            var daySleepInfo = new DaySleepInfo(day);
            daySleepInfo.GenerateHalfHourIntervals();
            for(int j = 0; j < 48; j++)
            {
                var hasSlept = reader.ReadBoolean();
                daySleepInfo.Intervals[j].HasSlept = hasSlept;
            }

            daySleepInfos.Add(daySleepInfo);
        }

        var sleepData = new SleepData();
        sleepData.DaySleepInfos.AddRange(daySleepInfos);

        return sleepData;
    }

    public object Deserialize(byte[] serialized, Type type)
    {
        if (type != ProvideType())
            throw new InvalidOperationException($"{this} cannot deserialize to '{type}'!");

        return Deserialize(serialized);
    }

    public Type ProvideType()
    {
        return typeof(SleepData);
    }

    public byte[] Serialize(SleepData data)
    {
        using var ms = new MemoryStream();
        var writer = new BinaryWriter(ms);
        writer.Write(data.DaySleepInfos.Count);
        foreach (var info in data.DaySleepInfos)
            WriteInfoToStream(writer, info);

        //ms.Position = 0;
        //var reader = new StreamReader(ms, Encoding.UTF8);
        //var serialized = reader.ReadToEnd();
        return ms.ToArray();
    }

    private void WriteInfoToStream(BinaryWriter writer, DaySleepInfo info)
    {
        writer.Write(info.Day.Ticks);
        for (var i = 0; i < 48; i++)
            WriteIntervalToStream(writer, info.Intervals[i]);
    }

    private void WriteIntervalToStream(BinaryWriter writer, SleepIntervalInfo sleepIntervalInfo)
    {
        writer.Write(sleepIntervalInfo.HasSlept);
    }

    public byte[] Serialize(object data)
    {
        if (data is SleepData sleepData)
            return Serialize(sleepData);

        throw new InvalidOperationException($"{this} cannot serialize '{data.GetType()}';");
    }
}
