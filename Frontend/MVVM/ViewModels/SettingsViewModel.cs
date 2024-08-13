using Frontend.Commands;
using Frontend.Core;
using Frontend.Services;

namespace Frontend.MVVM.ViewModels;

public class SettingsViewModel : ViewModelBase
{
    public SettingsViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;
    }

    public INavigationService NavigationService
    {
        get { return _navigationService; }
        set
        {
            _navigationService = value;
            OnPropertyChanged();
        }
    }

    public Command NavigateToHomeCommand { get { return GetCommand(NavigateToHome); } }

    private void NavigateToHome()
    {
        NavigationService.NavigateTo<HomeViewModel>();
    }

    private INavigationService _navigationService = null!;
}
