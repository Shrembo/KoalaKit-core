namespace KoalaKit.Primitives.Domain;

public abstract class KoalaEntity : IEquatable<KoalaEntity>
{
    public Guid Id { get; private set; }

    protected KoalaEntity() { }

    protected KoalaEntity(Guid id)
    {
        if (id == default)
            throw new ArgumentNullException(nameof(id));
        Id = id;
    }

    public static bool operator ==(KoalaEntity? first, KoalaEntity? second) =>
        Equals(first, second);

    public static bool operator !=(KoalaEntity? first, KoalaEntity? second) =>
        !Equals(first, second);

    public bool Equals(KoalaEntity? other) =>
        other is not null && GetType() == other.GetType() && Id == other.Id;

    public override bool Equals(object? obj) =>
        obj is KoalaEntity entity && Equals(entity);

    public override int GetHashCode() =>
        HashCode.Combine(Id, GetType());

    public override string ToString() =>
        $"{GetType().Name} {Id}";
}