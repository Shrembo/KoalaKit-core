namespace KoalaKit.Primitives.Extensions;

public static class DateExtensions
{
    public static bool IsBetween(this DateOnly date, DateOnly from, DateOnly to)
    {
        return date >= from && date <= to;
    }

    public static bool IsBetween(this DateTime date, DateTime from, DateTime to)
    {
        return date >= from && date <= to;
    }

    public static DateOnly Now(this DateOnly _)
    {
        return DateOnly.FromDateTime(DateTime.Now);
    }

    public static string GetTimeOnly(this DateTime dateTime, bool includeSeconds = false)
    {
        if (includeSeconds)
        {
            return dateTime.ToString("HH:mm:ss");
        }
        return dateTime.ToString("HH:mm");
    }

    public static string GetDateOnly(this DateTime dateTime)
    {
        return dateTime.ToString("yyyy-MM-dd");
    }
}