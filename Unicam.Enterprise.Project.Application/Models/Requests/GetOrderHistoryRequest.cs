namespace Unicam.Enterprise.Project.Application.Models.Requests;

public class GetOrderHistoryRequest
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int? UserId { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
} 
