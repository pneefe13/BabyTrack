using DataStructures.SaveData;
using Frontend.Commands;
using Frontend.Core;
using Frontend.Services;
using System.Windows;

namespace Frontend.MVVM.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel(INavigationService navigationService,
                         ISerializationService serializationService,
                         IFileService fileService)
    {
        NavigationService = navigationService;
        SerializationService = serializationService;
        FileService = fileService;
        _mainData = MainData.CreateDummy();
    }

    public Command NavigateToHomeCommand { get { return GetCommand(NavigateHome); } }

    public Command NavigateToSettingsCommand { get { return GetCommand(NavigateSettings); } }

    public Command SaveDataCommand { get { return GetCommand(SaveData); } }

    public Command LoadDataCommand { get { return GetCommand(LoadData); } }

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

    public IFileService FileService
    {
        get { return _fileService; }
        set { SetValue(ref _fileService, value); }
    }

    private void NavigateHome()
    {
        NavigationService.NavigateTo<HomeViewModel>();
    }

    private void NavigateSettings()
    {
        NavigationService.NavigateTo<SettingsViewModel>();
    }

    private void LoadData()
    {
        var loaded = FileService.LoadFromFile();
        if (loaded == null)
        {
            MessageBox.Show("No data was loaded!");
            return;
        }

        var deserialized = SerializationService.Deserialize(loaded, typeof(MainData));
        if (deserialized is not MainData mainData)
        {
            MessageBox.Show("Could not deserialize loaded data. Are the data corrupt?");
            return;
        }

        MainData = mainData;
        MessageBox.Show("Successfully loaded data!");
    }

    private void SaveData()
    {
        if (MainData is null)
        {
            MessageBox.Show("No data to save!");
            return;
        }

        var serialized = SerializationService.Serialize(MainData);
        var success = FileService.SaveToFile(serialized);
        if (!success)
            MessageBox.Show("No data was saved.");
    }

    public MainData MainData
    {
        get { return _mainData; }
        set { SetValue(ref _mainData, value); }
    }

    private MainData _mainData;

    private INavigationService _navigationService = null!;
    private ISerializationService _serializationService = null!;
    private IFileService _fileService = null!;
}
