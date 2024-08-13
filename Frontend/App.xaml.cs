using Frontend.Core;
using Frontend.MVVM.Models.SaveData;
using Frontend.MVVM.ViewModels;
using Frontend.Serialization;
using Frontend.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Frontend;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly ServiceProvider _serviceProvider;
    public App()
    {
        var services = new ServiceCollection();

        services.AddSingleton<MainWindow>(p => new MainWindow
        {
            DataContext = p.GetRequiredService<MainViewModel>()
        });

        AddViewModels(services);
        AddSerializers(services);
        AddServices(services);

        services.AddSingleton<Func<Type, ViewModelBase>>(provider => viewModelType => (ViewModelBase)provider.GetRequiredService(viewModelType));

        _serviceProvider = services.BuildServiceProvider();

    }

    private static void AddServices(ServiceCollection services)
    {
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<ISerializationService, SerializationService>();
        services.AddSingleton<IFileService, FileService>();
    }

    private static void AddSerializers(ServiceCollection services)
    {
        services.AddSingleton<ISerializer, SleepDataSerializer>();
        services.AddSingleton<ISerializer, BreastFeedDataSerializer>();
        services.AddSingleton<ISerializer, ToiletDataSerializer>();
        services.AddSingleton<ISerializer, MainDataSerializer>();
        services.AddSingleton<ITypedSerializer<SleepData>, SleepDataSerializer>();
        services.AddSingleton<ITypedSerializer<BreastFeedData>, BreastFeedDataSerializer>();
        services.AddSingleton<ITypedSerializer<ToiletData>, ToiletDataSerializer>();
        services.AddSingleton<ITypedSerializer<MainData>, MainDataSerializer>();
    }

    private static void AddViewModels(ServiceCollection services)
    {
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<HomeViewModel>();
        services.AddSingleton<SettingsViewModel>();
        services.AddSingleton<SleepViewModel>();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
        base.OnStartup(e);
    }
}
