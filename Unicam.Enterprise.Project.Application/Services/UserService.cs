using AutoMapper;
using Unicam.Enterpise.Project.Application.Models.Dtos;
using Unicam.Enterpise.Project.Application.Services.Abstractions;
using Unicam.Enterprise.Project.Infrastructure.Repositories;

namespace Unicam.Enterpise.Project.Application.Services;

public class UserService : IUserService
{
    private readonly UserRepository _userRepository;
    private readonly IMapper _mapper;
    
    public UserService(UserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public UserDto GetUser(int id)
    {
        var user = _userRepository.Get(id);
        return _mapper.Map<UserDto>(user);
    }
}