using Unicam.Paradigmi.Project.Application.Models.Dtos;
using Unicam.Paradigmi.Project.Model.Entities;

namespace Unicam.Paradigmi.Project.Application.Services.Abstractions;

public interface IUserService
{
    User GetUser(int id); 
}