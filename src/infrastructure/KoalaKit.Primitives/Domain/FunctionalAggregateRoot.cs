namespace KoalaKit.Primitives.Domain;

public abstract class FunctionalAggregateRoot : AggregateRoot, ICreateable, IUpdatable, IDeletable
{
    public Guid CreatedById { get; private set; }
    public DateTime CreatedDate { get; private set; }

    public bool Deleted { get; set; }
    public Guid? DeletedBy { get; set; }
    public DateTime? DeletedDate { get; set; }

    public Guid? LastUpdateBy { get; private set; }
    public DateTime? LastUpdateDate { get; private set; }

    protected FunctionalAggregateRoot() { }

    protected FunctionalAggregateRoot(Guid id) : base(id)
    {
        CreatedDate = DateTime.UtcNow;
    }

    protected FunctionalAggregateRoot(Guid id, Guid createdBy, DateTime createdDate) : base(id)
    {
        CreatedById = createdBy;
        CreatedDate = createdDate;
    }

    public virtual void Update(DateTime now)
    {
        LastUpdateBy = Guid.Empty;
        LastUpdateDate = now;
    }

    public virtual void Update(Guid employeeId, DateTime now)
    {
        LastUpdateBy = employeeId;
        LastUpdateDate = now;
    }
}