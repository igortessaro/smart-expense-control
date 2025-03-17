using MediatR;
using SmartExpenseControl.Domain.DataObjectTransfer;

namespace SmartExpenseControl.Application;

public class PaginationQuery<T>(int pageNumber, int pageSize) : IRequest<PagedResponseOffset<T>> where T : class
{
    public int PageNumber { get; } = pageNumber;
    public int PageSize { get; } = pageSize;
}
