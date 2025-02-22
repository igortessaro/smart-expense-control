namespace SmartExpenseControl.Domain.DataObjectTransfer;

public class PagedResponseOffset<T>(int? pageNumber, int pageSize, int totalRecords, List<T> data) where T : class
{
    public int PageNumber { get; init; } = pageNumber ?? 0;
    public int PageSize { get; init; } = pageSize;
    public int TotalRecords { get; init; } = totalRecords;
    public int TotalPages => (int) Math.Ceiling(TotalRecords / (double) PageSize);
    public IReadOnlyList<T> Data { get; init; } = data;
}
