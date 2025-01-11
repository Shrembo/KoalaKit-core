namespace KoalaKit.Serializations;

public interface IKoalaSerializer<TData>
{
    TData? Deserialize(byte[] bytes);
    byte[] Serialize(TData message);
}
