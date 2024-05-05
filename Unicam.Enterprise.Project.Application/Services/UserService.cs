using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Unicam.Enterprise.Project.Application.Models.DTOs;
using Unicam.Enterprise.Project.Application.Models.Requests;
using Unicam.Enterprise.Project.Application.Models.Responses;
using Unicam.Enterprise.Project.Application.Options;
using Unicam.Enterprise.Project.Application.Services.Abstractions;
using Unicam.Enterprise.Project.Infrastructure.Repositories.Abstractions;
using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly JwtSettingsOption _jwtSettingsOption;
    private readonly IMapper _mapper;
    
    public UserService(IUserRepository userRepository, IOptions<JwtSettingsOption> jwtSettingsOption, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _jwtSettingsOption = jwtSettingsOption.Value;
    }
    
    public async Task<CreateUserResponse> CreateUser(CreateUserRequest request)
    {
        var user = _mapper.Map<User>(request);
        user.Role = Role.Customer;
        
        await _userRepository.Insert(user);
        await _userRepository.Save();
        
        var orderDto = _mapper.Map<UserDto>(user);
        
        return new CreateUserResponse(orderDto);
    }
    
    public async Task<LoginResponse> Login(LoginRequest request)
    {
        var user = await _userRepository.GetUserByEmail(request.Email);
        
        if (user == null || user.Password != request.Password)
        {
            throw new AuthenticationException("User not found.");
        }
        
        var token = GenerateJwtToken(CreateClaims(user));
        
        return new LoginResponse(token);
    }
    
    private static IEnumerable<Claim> CreateClaims(User user)
    {
        return new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Name),
            new(ClaimTypes.Surname, user.Surname),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Role, user.Role.ToString())
        };
    }
    
    private string GenerateJwtToken(IEnumerable<Claim> claims)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettingsOption.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Issuer = _jwtSettingsOption.Issuer,
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_jwtSettingsOption.ExpirationTime),
            SigningCredentials = credentials
        });
        return tokenHandler.WriteToken(token);
    }
}