using Frontend.Core;

namespace Frontend.MVVM.Models.SaveData;

public class MainData : ObservableObject
{
    public MainData(BreastFeedData breastFeedData, ToiletData toiletData, SleepData sleepData)
    {
        BreastFeedData = breastFeedData;
        ToiletData = toiletData;
        SleepData = sleepData;
    }

    public static MainData CreateDummy()
    {
        return new MainData(new BreastFeedData(), new ToiletData(), new SleepData());
    }

    public BreastFeedData BreastFeedData { get; private init; }

    public ToiletData ToiletData { get; private init; }

    public SleepData SleepData { get; private init; }
}
