using Frontend.Commands;
using Frontend.Core;
using Frontend.Services;

namespace Frontend.MVVM.ViewModels;

public class HomeViewModel : ViewModelBase
{
    public HomeViewModel(INavigationService navigationService)
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

    public Command NavigateToSettingsCommand { get { return GetCommand(NavigateToSettings); } }

    private void NavigateToSettings()
    {
        NavigationService.NavigateTo<SettingsViewModel>();
    }

    private INavigationService _navigationService = null!;
}
