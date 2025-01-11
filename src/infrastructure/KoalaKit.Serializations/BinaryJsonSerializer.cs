using System.Text.Json;
using System.Text;
using KoalaKit.Primitives.Extensions;

namespace KoalaKit.Serializations;

public class BinaryJsonSerializer<TData> : IKoalaSerializer<TData>
{
    public virtual TData? Deserialize(byte[]? bytes)
    {
        if (bytes.HasItems())
        {
            return JsonSerializer.Deserialize<TData>(Encoding.UTF8.GetString(bytes));
        }
        return default;
    }

    public virtual byte[] Serialize(TData message)
        => Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
}
