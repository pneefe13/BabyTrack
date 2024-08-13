namespace DataStructures;

public class Time
{
    public Time(int hour, int minute)
    {
        Hour = hour;
        Minute = minute;
    }

    public int Hour { get; private init; }

    public int Minute { get; private init; }
}
