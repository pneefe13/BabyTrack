using Frontend.Commands;
using Frontend.Core;
using Frontend.Services;

namespace Frontend.MVVM.ViewModels;

public class SettingsViewModel : ViewModelBase
{
    public SettingsViewModel(INavigationService navigationService, IMainDataService mainDataService) : base(navigationService, mainDataService)
    {
    }

    public Command NavigateToHomeCommand { get { return GetCommand(NavigateToHome); } }

    private void NavigateToHome()
    {
        NavigationService.NavigateTo<HomeViewModel>();
    }
}
