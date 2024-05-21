
namespace Unicam.Enterprise.Project.Model.Entities;

/// <summary>
/// Represents an address.
/// </summary>
public class Address
{
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
}