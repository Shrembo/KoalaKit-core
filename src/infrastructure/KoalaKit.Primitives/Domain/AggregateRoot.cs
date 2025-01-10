namespace KoalaKit.Primitives.Domain;

public abstract class AggregateRoot : KoalaEntity
{
    protected AggregateRoot() { }
    protected AggregateRoot(Guid id) : base(id) { }

}