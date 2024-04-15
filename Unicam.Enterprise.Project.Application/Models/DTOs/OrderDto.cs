using Unicam.Enterprise.Project.Model.Entities;
using System;
using System.Collections.Generic;

namespace Unicam.Enterprise.Project.Application.Models.DTOs;

public class OrderDto
{
    public int Id { get; init; }
    public DateTime Date { get; init; }
    public AddressDto DeliveryAddress { get; init; } = new AddressDto();
    public List<CourseDto> Courses { get; init; } = new List<CourseDto>();
    public int UserId { get; init; }
    public UserDto User { get; init; } = new UserDto();
    public string TotalPrice { get; init; } = string.Empty;
}