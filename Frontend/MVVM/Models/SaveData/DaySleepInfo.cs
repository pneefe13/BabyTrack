using Frontend.Core;

namespace Frontend.MVVM.Models.SaveData;

public class DaySleepInfo : ObservableObject
{
    public DaySleepInfo(DateTime day)
    {
        Day = new DateTime(day.Year, day.Month, day.Day, 0, 0, 0);
    }

    public DateTime Day { get; private init; }

    List<SleepIntervalInfo> Intervals { get; } = [];
}
