using Unicam.Paradigmi.Project.Application.Abstractions.Services;
using Unicam.Paradigmi.Project.Infrastructure.Repositories;
using Unicam.Paradigmi.Project.Model.Entities;

namespace Unicam.Paradigmi.Project.Application.Services;

public class UserService : IUserService
{
    private readonly UserRepository _userRepository;
    
    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public User GetUser(int id)
    {
        return _userRepository.Get(id);
    }
    
    public void AddUser(User user)
    {
        _userRepository.Add(user);
        _userRepository.Save();
    }
}