using Frontend.Core;

namespace Frontend.MVVM.Models.SaveData;

public class SleepData : ObservableObject
{
    public List<DaySleepInfo> DaySleepInfos { get; } = [];
}
