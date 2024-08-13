using Frontend.Commands;
using Frontend.Core;
using Frontend.Services;

namespace Frontend.MVVM.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel(INavigationService navigationService, ISerializationService serializationService)
    {
        NavigationService = navigationService;
        SerializationService = serializationService;
    }

    public Command NavigateToHomeCommand { get { return GetCommand(NavigateHome); } }

    public Command NavigateToSettingsCommand { get { return GetCommand(NavigateSettings); } }

    public INavigationService NavigationService
    {
        get { return _navigationService; }
        set { SetValue(ref _navigationService, value); }
    }

    public ISerializationService SerializationService
    {
        get { return _serializationService; }
        set { SetValue(ref _serializationService, value); }
    }

    private void NavigateHome()
    {
        NavigationService.NavigateTo<HomeViewModel>();
    }

    private void NavigateSettings()
    {
        NavigationService.NavigateTo<SettingsViewModel>();
    }

    private INavigationService _navigationService = null!;
    private ISerializationService _serializationService = null!;
}
