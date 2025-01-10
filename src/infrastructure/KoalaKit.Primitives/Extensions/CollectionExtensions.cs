using System.Diagnostics.CodeAnalysis;

namespace KoalaKit.Primitives.Extensions;

public static class CollectionExtensions
{
    public static bool HasItems<T>([NotNullWhen(true)] this IEnumerable<T>? collection)
    {
        if (collection == null)
        {
            return false;
        }
        return collection.Any();
    }
}