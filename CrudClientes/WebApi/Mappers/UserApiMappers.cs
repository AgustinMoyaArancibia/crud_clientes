using Application.Features.Users.Models;
using WebApi.Contracts.Users.Requests;
using WebApi.Contracts.Users.Responses;

namespace WebApi.Mappers;

public static class UserApiMappers
{
    public static UserCreateDto ToApp(this UserCreateRequest r)
        => new(r.Email, r.Password, r.FullName, r.Role);

    public static UserUpdateDto ToApp(this UserUpdateRequest r)
        => new(r.FullName, r.Role, r.Active);

    public static UserResponse ToResponse(this UserReadDto d)
        => new()
        {
            Id = d.Id,
            Email = d.Email,
            FullName = d.FullName,
            Role = d.Role,
            Active = d.Active,
            CreatedAt = d.CreatedAt
        };
}
