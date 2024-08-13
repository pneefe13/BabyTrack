using Frontend.Commands;
using Frontend.Core;
using Frontend.MVVM.Models.SaveData;
using Frontend.Services;
using System.Windows.Ink;

namespace Frontend.MVVM.ViewModels;
public class SleepViewModel : ViewModelBase
{
    public SleepViewModel(INavigationService navigationService, IMainDataService mainDataService) : base(navigationService,
                                                                                                         mainDataService)
    {
        
    }

    public Command AddDayCommand { get { return GetCommand(AddDay); } }

    private void AddDay()
    {
        var sleepInfos = MainDataService.MainData.SleepData.DaySleepInfos;
        var newer = GetNewestDayToAdd(sleepInfos);
        sleepInfos.Add(new DaySleepInfo(newer));
    }

    private static DateTime GetNewestDayToAdd(List<DaySleepInfo> sleepInfos)
    {
        if (sleepInfos.Any())
        {
            var latest = sleepInfos.Max(i => i.Day);
            return latest.AddDays(1);
        }
        else
            return DateTime.UtcNow;
    }
}
