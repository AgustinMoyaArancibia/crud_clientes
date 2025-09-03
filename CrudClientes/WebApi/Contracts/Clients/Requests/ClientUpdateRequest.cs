namespace WebApi.Contracts.Clients.Requests;

public class ClientUpdateRequest
{
    public string Name { get; set; } = default!;
    public string ShippingAddress { get; set; } = string.Empty;
    public bool Active { get; set; }
}
