using Frontend.Core;

namespace Frontend.Services;

public interface INavigationService
{
    ViewModelBase CurrentViewModel { get; }

    void NavigateTo<TViewModel>() where TViewModel : ViewModelBase;
}
