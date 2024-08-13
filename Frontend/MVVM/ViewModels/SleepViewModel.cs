using Frontend.Commands;
using Frontend.Core;
using Frontend.Services;

namespace Frontend.MVVM.ViewModels;
public class SleepViewModel : ViewModelBase
{
    public SleepViewModel(INavigationService navigationService) : base(navigationService)
    {
        
    }

    public Command AddDayCommand { get { return GetCommand(AddDay); } }

    private void AddDay()
    {
        throw new NotImplementedException();
    }
}
