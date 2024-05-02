
namespace Unicam.Enterprise.Project.Model.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
    
    public ICollection<Order> Orders { get; set; }
}