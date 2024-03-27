using Unicam.Paradigmi.Project.Model.Entities;

namespace Unicam.Paradigmi.Project.Application.Abstractions.Services;

public interface IUserService
{
    User GetUser(int id);
    void AddUser(User user);
}