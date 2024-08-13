using Frontend.MVVM.Models.SaveData;

namespace Frontend.Services;
public interface IMainDataService
{
    MainData MainData { get; }

    void SetData(MainData mainData);
}