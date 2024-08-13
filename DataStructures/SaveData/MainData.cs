namespace DataStructures.SaveData;

public class MainData
{
    public MainData(BreastFeedData breastFeedData, ToiletData toiletData, SleepData sleepData)
    {
        BreastFeedData = breastFeedData;
        ToiletData = toiletData;
        SleepData = sleepData;
    }

    public BreastFeedData BreastFeedData { get; private init; }

    public ToiletData ToiletData { get; private init; }

    public SleepData SleepData { get; private init; }
}
