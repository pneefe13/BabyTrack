using Frontend.Core;

namespace Frontend.Services;
public class NavigationService : ObservableObject, INavigationService
{
    public NavigationService(Func<Type, ViewModelBase> viewModelFactory)
    {
        _viewModelFactory = viewModelFactory;
    }

    public ViewModelBase CurrentViewModel
    {
        get { return _currentViewModel; }
        private set { SetValue(ref _currentViewModel, value); }
    }


    public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
    {
        var viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
        CurrentViewModel = viewModel;
    }

    private readonly Func<Type, ViewModelBase> _viewModelFactory;

    private ViewModelBase _currentViewModel = null!;
}
