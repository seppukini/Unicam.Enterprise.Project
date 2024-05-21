
namespace Unicam.Enterprise.Project.Model.Entities;

// Customer class
public class User
{
    public int Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Role Role { get; set; }

    // Dishes taken for each customer
    public IEnumerable<Order> Orders { get; set; } = new List<Order>();
}