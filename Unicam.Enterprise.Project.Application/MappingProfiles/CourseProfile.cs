using AutoMapper;
using Unicam.Enterprise.Project.Application.Models.DTOs;
using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Application.MappingProfiles;

/// <summary>
/// Mapping profile for the Course entity.
/// </summary>
public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<Course, CourseDto>()
            .ForMember(dest => dest.Price, opt
                => opt.MapFrom(src => src.Price.ToString("F2")));
    }
}