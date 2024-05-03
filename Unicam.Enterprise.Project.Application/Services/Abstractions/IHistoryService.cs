using Unicam.Enterprise.Project.Application.Models.DTOs;
using Unicam.Enterprise.Project.Application.Models.Requests;

namespace Unicam.Enterprise.Project.Application.Services.Abstractions;

using System.Collections.Generic;

public interface IHistoryService
{
    Task<IEnumerable<OrderDto>> GetOrderHistory(GetOrderHistoryRequest request, int userId, string userRole);
}
