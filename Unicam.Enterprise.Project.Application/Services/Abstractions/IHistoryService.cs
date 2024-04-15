namespace Unicam.Enterprise.Project.Application.Services.Abstractions;

using System;
using System.Collections.Generic;
using Unicam.Enterprise.Project.Application.Models.DTOs;

public interface IHistoryService
{
    IEnumerable<OrderDto> GetOrderHistory(DateTime startDate, DateTime endDate, int? userId, int userRoleId,
        int pageIndex, int pageSize);
}
