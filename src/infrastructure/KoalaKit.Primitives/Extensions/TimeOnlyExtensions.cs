namespace KoalaKit.Primitives.Extensions;

public static class TimeOnlyExtensions
{
    public static string AsString(this TimeOnly timeSpan, bool includeSeconds = false)
    {
        if (includeSeconds)
        {
            return timeSpan.ToString("hh\\:mm\\:ss");
        }
        return timeSpan.ToString("hh\\:mm");

    }

    public static TimeOnly CleareTimeOnly(this TimeOnly time, bool includeSeconds = false)
    {
        if (includeSeconds)
        {
            return new TimeOnly(time.Hour, time.Minute, time.Second);
        }
        return new TimeOnly(time.Hour, time.Minute);
    }
}