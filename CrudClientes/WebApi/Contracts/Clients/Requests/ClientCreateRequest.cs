namespace WebApi.Contracts.Clients.Requests;

public class ClientCreateRequest
{
    public string Dni { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string ShippingAddress { get; set; } = string.Empty;
}
