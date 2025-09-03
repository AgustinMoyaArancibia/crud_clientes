namespace Application.Features.Users.Models;

/// <summary>
/// DTO para login: se envía email y password.
/// </summary>
public record UserLoginDto(string Email, string Password);
