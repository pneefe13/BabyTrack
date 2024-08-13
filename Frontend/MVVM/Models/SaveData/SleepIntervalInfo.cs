using DataStructures;
using Frontend.Core;

namespace Frontend.MVVM.Models.SaveData;

public class SleepIntervalInfo : ObservableObject
{
    public SleepIntervalInfo(TimeOnly start, TimeOnly end, bool hasSlept)
    {
        Start = start;
        End = end;
        HasSlept = hasSlept;
    }

    public TimeOnly Start { get; private init; }

    public TimeOnly End { get; private init; }

    public bool HasSlept
    {
        get { return _hasSlept; }
        set
        {
            SetValue(ref _hasSlept, value);
        }
    }

    private bool _hasSlept;
}
