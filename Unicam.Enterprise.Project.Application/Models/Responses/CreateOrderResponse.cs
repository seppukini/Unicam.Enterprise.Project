
namespace Unicam.Enterprise.Project.Application.Models.Responses;

public class CreateOrderResponse
{
    public CreateOrderResponse(int orderNumber, decimal totalPrice)
    {
        OrderNumber = orderNumber;
        TotalPrice = totalPrice.ToString("F2");
    }
    
    public int OrderNumber { get; set; }
    public string TotalPrice { get; set; }

}