using Unicam.Enterprise.Project.Application.Models.DTOs;

namespace Unicam.Enterprise.Project.Application.Models.Responses;

public class GetOrderHistoryResponse
{
    public GetOrderHistoryResponse(IEnumerable<OrderDto> history, int totalPagesFound)
    {
        History = history;
        TotalPagesFound = totalPagesFound;
    }

    public IEnumerable<OrderDto> History { get; set; }
    public int TotalPagesFound { get; set; }
}