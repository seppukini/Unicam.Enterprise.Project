using AutoMapper;
using Unicam.Enterprise.Project.Application.Models.Dtos;
using Unicam.Enterprise.Project.Application.Services.Abstractions;
using Unicam.Enterprise.Project.Infrastructure.Repositories;

namespace Unicam.Enterprise.Project.Application.Services;

public class UserService : IUserService
{
    private readonly UserRepositoryBase _userRepositoryBase;
    private readonly IMapper _mapper;
    
    public UserService(UserRepositoryBase userRepositoryBase, IMapper mapper)
    {
        _userRepositoryBase = userRepositoryBase;
        _mapper = mapper;
    }
    
    public UserDto GetUser(int id)
    {
        var user = _userRepositoryBase.GetById(id);
        return _mapper.Map<UserDto>(user);
    }
}