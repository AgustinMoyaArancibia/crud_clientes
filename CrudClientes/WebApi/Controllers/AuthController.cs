using Application.Abstractions;                  // IAuthService
using Application.Features.Users.Models;        // UserLoginDto / UserCreateDto
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(
    IAuthService auth,
    IValidator<UserLoginDto> loginVal,
    IValidator<UserCreateDto> registerVal
) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto dto, CancellationToken ct)
    {
        var v = await loginVal.ValidateAsync(dto, ct);
        if (!v.IsValid)
        {
            foreach (var e in v.Errors)
                ModelState.AddModelError(e.PropertyName, e.ErrorMessage);
            return ValidationProblem(ModelState);
        }

        var token = await auth.LoginAsync(dto, ct);
        return Ok(new { token });
    }

    // si querés permitir registro desde Auth; si no, podés moverlo a UsersController (AdminOnly)
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserCreateDto dto, CancellationToken ct)
    {
        var v = await registerVal.ValidateAsync(dto, ct);
        if (!v.IsValid)
        {
            foreach (var e in v.Errors)
                ModelState.AddModelError(e.PropertyName, e.ErrorMessage);
            return ValidationProblem(ModelState);
        }

        var id = await auth.RegisterAsync(dto, ct);
        return CreatedAtAction(nameof(Register), new { id }, null);
    }
}
