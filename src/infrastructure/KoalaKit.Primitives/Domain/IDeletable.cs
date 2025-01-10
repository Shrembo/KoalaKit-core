namespace KoalaKit.Primitives.Domain;

public interface IDeletable
{
    bool Deleted { get; set; }
    Guid? DeletedBy { get; set; }
    DateTime? DeletedDate { get; set; }
}