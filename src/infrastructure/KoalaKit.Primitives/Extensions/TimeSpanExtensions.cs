namespace KoalaKit.Primitives.Extensions;

public static class TimeSpanExtensions
{
    public static string AsString(this TimeSpan timeSpan, bool includeSeconds = false)
    {
        if (includeSeconds)
        {
            return timeSpan.ToString("hh\\:mm\\:ss");
        }
        return (timeSpan < TimeSpan.Zero ? "-" : "") + timeSpan.ToString("hh\\:mm");
    }

    public static TimeSpan ClearTimeSpan(this TimeSpan timeSpan, bool includeSeconds = false)
    {
        if (includeSeconds)
        {
            return new TimeSpan(timeSpan.Days, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        }
        return new TimeSpan(timeSpan.Days, timeSpan.Hours, timeSpan.Minutes, 0);
    }
}