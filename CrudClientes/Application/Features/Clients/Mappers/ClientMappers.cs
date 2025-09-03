using Application.Features.Clients.Models;
using Domain.Entities;

namespace Application.Features.Clients.Mappers;

public static class ClientMappers
{
    public static ClientReadDto ToReadDto(this Client e)
        => new(e.Id, e.Dni, e.Name, e.ShippingAddres, e.Active, e.CreatedAt);
}
