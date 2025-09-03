namespace WebApi.Contracts.Users.Requests;

public class UserCreateRequest
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string FullName { get; set; } = default!;
    public string Role { get; set; } = "Employee"; // Admin | Supervisor | Employee
}
