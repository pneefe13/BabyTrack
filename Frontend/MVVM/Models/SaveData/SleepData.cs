using Frontend.Core;

namespace Frontend.MVVM.Models.SaveData;

public class SleepData : ObservableObject
{
    List<DaySleepInfo> DaySleepInfos { get; } = [];
}
