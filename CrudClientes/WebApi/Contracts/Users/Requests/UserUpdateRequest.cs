namespace WebApi.Contracts.Users.Requests;

public class UserUpdateRequest
{
    public string FullName { get; set; } = default!;
    public string Role { get; set; } = default!;
    public bool Active { get; set; }
}
