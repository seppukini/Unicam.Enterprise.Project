using Unicam.Enterprise.Project.Application.Models.DTOs;

namespace Unicam.Enterprise.Project.Application.Models.Responses;

public class GetOrderHistoryResponse
{
    public GetOrderHistoryResponse(IEnumerable<OrderDto> history)
    {
        History = history;
    }

    public IEnumerable<OrderDto> History { get; set; }
}