using Application.Features.Users.Models;

namespace Application.Abstractions;

/// Contrato de autenticación para la capa de aplicación.
/// Lo implementa la infraestructura (AuthService).
public interface IAuthService
{
    Task<string> LoginAsync(UserLoginDto dto, CancellationToken ct = default);
    Task<int> RegisterAsync(UserCreateDto dto, CancellationToken ct = default);
}
