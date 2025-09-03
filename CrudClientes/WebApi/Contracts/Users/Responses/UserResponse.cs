namespace WebApi.Contracts.Users.Responses;

public class UserResponse
{
    public int Id { get; set; }
    public string Email { get; set; } = default!;
    public string FullName { get; set; } = default!;
    public string Role { get; set; } = default!;
    public bool Active { get; set; }
    public DateTime CreatedAt { get; set; }
}
