namespace KoalaKit.Primitives.Domain;

public interface ICreateable
{
    Guid CreatedById { get; }
    DateTime CreatedDate { get; }
}