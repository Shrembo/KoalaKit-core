namespace KoalaKit.Primitives.Domain;

public interface IUpdatable
{
    Guid? LastUpdateBy { get; }
    DateTime? LastUpdateDate { get; }

    void Update(DateTime now);
    void Update(Guid employeeId, DateTime now);
}