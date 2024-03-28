using AutoMapper;
using Unicam.Enterpise.Project.Application.Models.Dtos;
using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterpise.Project.Application.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
    }
}