using System.Text.RegularExpressions;

namespace KoalaKit.Primitives.Extensions;

public static class StringExtensions
{
    public static bool IsValidEmail(this string email)
    {
        var emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        var regex = new Regex(emailRegex, RegexOptions.IgnoreCase);
        return regex.IsMatch(email);
    }
}