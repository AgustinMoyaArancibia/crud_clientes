using Application.Features.Clients.Models;
using WebApi.Contracts.Clients.Requests;
using WebApi.Contracts.Clients.Responses;

namespace WebApi.Mappers;

public static class ClientApiMappers
{
    public static ClientCreateDto ToApp(this ClientCreateRequest r)
        => new(r.Dni, r.Name, r.ShippingAddress);

    public static ClientUpdateDto ToApp(this ClientUpdateRequest r)
        => new(r.Name, r.ShippingAddress, r.Active);

    public static ClientResponse ToResponse(this ClientReadDto d)
        => new()
        {
            Id = d.Id,
            Dni = d.Dni,
            Name = d.Name,
            ShippingAddress = d.ShippingAddress,
            Active = d.Active,
            CreatedAt = d.CreatedAt
        };
}
