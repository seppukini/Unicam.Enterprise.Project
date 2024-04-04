using AutoMapper;
using Unicam.Enterprise.Project.Application.Models.DTOs;
using Unicam.Enterprise.Project.Application.Models.Requests;
using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Application.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<CreateUserRequest, User>();
    }
}