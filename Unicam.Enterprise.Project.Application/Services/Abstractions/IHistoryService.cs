using Unicam.Enterprise.Project.Application.Models.Requests;
using Unicam.Enterprise.Project.Application.Models.Responses;

namespace Unicam.Enterprise.Project.Application.Services.Abstractions;

public interface IHistoryService
{
    Task<GetOrderHistoryResponse> GetOrderHistory(GetOrderHistoryRequest request, int userId, string userRole);
}
