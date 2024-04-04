namespace Unicam.Enterprise.Project.Application.Options;

public class JwtSettingsOption
{
    public string Key { get; init; } = string.Empty;
    public string Issuer { get; init; } = string.Empty;
    public int ExpirationTime { get; init; }
}