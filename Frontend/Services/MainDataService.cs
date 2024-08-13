using Frontend.Core;
using Frontend.MVVM.Models.SaveData;
using System.Windows;

namespace Frontend.Services;
public class MainDataService : ObservableObject, IMainDataService
{
    public MainDataService()
    {
        _mainData = MainData.CreateDummy();
    }

    public void SetData(MainData mainData)
    {
        MainData = mainData;
    }

    public MainData MainData
    {
        get { return _mainData; }
        private set { SetValue(ref _mainData, value); }
    }

    private MainData _mainData;
}
