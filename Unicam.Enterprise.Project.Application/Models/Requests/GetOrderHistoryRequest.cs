namespace Unicam.Enterprise.Project.Application.Models.Requests;

public class GetOrderHistoryRequest
{
    public DateTime StartDate { get; set; } = DateTime.MinValue;
    public DateTime EndDate { get; set; } = DateTime.MaxValue;
    public int? UserId { get; set; } = null;
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;
} 
