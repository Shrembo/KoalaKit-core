using KoalaKit.Primitives.Domain;
using KoalaKit.Primitives.Paginations;

namespace KoalaKit.Primitives.Titled;

public sealed record TitledValue(Guid Id, string Value) : PaginatedItem;
public sealed record TitledValue<TValue>(TValue Id, string Value) : PaginatedItem where TValue : struct;

public static class TitledSelectors
{
    public static Func<T, TitledValue> AsTitledValue<T>(bool isArabic)
        where T : KoalaEntity, ITitledEntity
    {
        return entity => new TitledValue(entity.Id, entity.GetTitle(isArabic));
    }
}