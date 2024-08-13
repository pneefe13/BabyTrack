using Frontend.Commands;
using Frontend.Core;
using Frontend.Services;

namespace Frontend.MVVM.ViewModels;

public class HomeViewModel : ViewModelBase
{
    public HomeViewModel(INavigationService navigationService) : base(navigationService) 
    {
    }

    public Command NavigateToSettingsCommand { get { return GetCommand(NavigateToSettings); } }

    private void NavigateToSettings()
    {
        NavigationService.NavigateTo<SettingsViewModel>();
    }
}
