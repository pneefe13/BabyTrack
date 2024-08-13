using DataStructures;
using Frontend.Core;

namespace Frontend.MVVM.Models.SaveData;

public class SleepIntervalInfo : ObservableObject
{
    public SleepIntervalInfo(Time start, Time end)
    {
        Start = start;
        End = end;
    }

    public Time Start { get; private init; }

    public Time End { get; private init; }
}
