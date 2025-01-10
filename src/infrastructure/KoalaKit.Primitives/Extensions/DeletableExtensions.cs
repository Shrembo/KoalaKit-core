using KoalaKit.Primitives.Domain;

namespace KoalaKit.Primitives.Extensions;

public static class DeletableExtensions
{
    public static void Delete(this IDeletable entity, DateTime now)
    {
        entity.Deleted = true;
        entity.DeletedDate = now;
    }

    public static void Delete(this IDeletable entity, DateTime now, Guid employeeId)
    {
        entity.Deleted = true;
        entity.DeletedDate = now;
        entity.DeletedBy = employeeId;
    }
}