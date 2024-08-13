namespace Frontend.MVVM.Models.SaveData;

public class SleepData
{
    List<DaySleepInfo> DaySleepInfos { get; } = [];
}

public class DaySleepInfo
{
    public DaySleepInfo(DateTime day)
    {
        Day = new DateTime(day.Year, day.Month, day.Day, 0, 0, 0);
    }

    public DateTime Day { get; private init; }

    List<SleepIntervalInfo> Intervals { get; } = [];
}

public class SleepIntervalInfo
{
    public SleepIntervalInfo(Time start, Time end)
    {
        Start = start;
        End = end;
    }

    public Time Start { get; private init; }

    public Time End { get; private init; }
}

public class Time
{
    public Time(int hour, int minute)
    {
        Hour = hour;
        Minute = minute;
    }

    public int Hour { get; private init; }

    public int Minute { get; private init; }
}
