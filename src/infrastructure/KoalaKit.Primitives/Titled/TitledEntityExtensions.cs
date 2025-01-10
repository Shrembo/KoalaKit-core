namespace KoalaKit.Primitives.Titled;


public static class TitledEntityExtensions
{
    public static string GetTitle<TEntity>(this TEntity entity, bool isArabic)
        where TEntity : ITitledEntity
    {
        if (isArabic == true)
        {
            return entity.TitleAr;
        }
        return entity.TitleEn;
    }
}