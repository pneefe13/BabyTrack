using Frontend.Core;
using System.Collections.ObjectModel;

namespace Frontend.MVVM.Models.SaveData;

public class SleepData : ObservableObject
{
    public SleepData()
    {
        _daySleepInfos = [];
    }

    private ObservableCollection<DaySleepInfo> _daySleepInfos;

    public void AddInfo(DaySleepInfo daySleepInfo)
    {
        DaySleepInfos.Add(daySleepInfo);
    }

    public ObservableCollection<DaySleepInfo> DaySleepInfos 
    { 
        get { return _daySleepInfos; } 
        set 
        {
            SetValue(ref _daySleepInfos, value); 
        }
    }
}
