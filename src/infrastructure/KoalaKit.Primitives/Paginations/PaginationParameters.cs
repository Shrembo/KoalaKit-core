namespace KoalaKit.Primitives.Paginations;

public record PaginationParameters
{
    public int PageSize { get; init; } = 10;
    public int PageNumber { get; init; } = 1;
}