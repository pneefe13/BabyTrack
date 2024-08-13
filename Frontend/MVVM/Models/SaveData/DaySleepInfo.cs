using Frontend.Core;
using System.Collections.ObjectModel;

namespace Frontend.MVVM.Models.SaveData;

public class DaySleepInfo : ObservableObject
{
    public DaySleepInfo(DateTime day)
    {
        Day = new DateTime(day.Year, day.Month, day.Day, 0, 0, 0);
        _intervals = [];
        GenerateHalfHourIntervals();
    }

    public void GenerateHalfHourIntervals()
    {
        for (int i = 0; i < 48; i++)
        {
            var start = TimeOnly.FromTimeSpan(TimeSpan.FromMinutes(i * 30));
            var end = TimeOnly.FromTimeSpan(TimeSpan.FromMinutes((i + 1) * 30 % 1440)); // % 1440 ensures wrap-around to 0:00

            Intervals.Add(new SleepIntervalInfo(start, end, false));
        }
    }

    public DateTime Day { get; private init; }

    public ObservableCollection<SleepIntervalInfo> Intervals
    {
        get { return _intervals; }
        set 
        {
            SetValue(ref _intervals, value); }
        }

    private ObservableCollection<SleepIntervalInfo> _intervals;
}
