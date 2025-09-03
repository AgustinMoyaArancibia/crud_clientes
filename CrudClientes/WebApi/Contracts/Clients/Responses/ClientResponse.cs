namespace WebApi.Contracts.Clients.Responses;

public class ClientResponse
{
    public int Id { get; set; }
    public string Dni { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string ShippingAddress { get; set; } = string.Empty;
    public bool Active { get; set; }
    public DateTime CreatedAt { get; set; }
}
