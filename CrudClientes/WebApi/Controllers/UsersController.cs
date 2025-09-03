using Application.Common.Paging;
using Application.Features.Users.Services;      // IUserService
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contracts.Users.Requests;
using WebApi.Mappers;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "SupervisorOrAdmin")]
public class UsersController(IUserService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int page = 1, [FromQuery] int size = 10, [FromQuery] string? search = null, CancellationToken ct = default)
    {
        var result = await service.GetAsync(new PagedRequest(page, size, search), ct);
        return Ok(new { result.Items, result.Total, result.Page, result.Size });
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken ct)
    {
        var r = await service.GetByIdAsync(id, ct);
        return r.Succeeded ? Ok(r.Value!.ToResponse()) : NotFound(new { error = r.Error });
    }

    [HttpPost]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> Create([FromBody] UserCreateRequest req, CancellationToken ct)
    {
        var r = await service.CreateAsync(req.ToApp(), ct);
        return r.Succeeded
            ? CreatedAtAction(nameof(GetById), new { id = r.Value }, null)
            : BadRequest(new { error = r.Error });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UserUpdateRequest req, CancellationToken ct)
    {
        var r = await service.UpdateAsync(id, req.ToApp(), ct);
        return r.Succeeded ? NoContent() : BadRequest(new { error = r.Error });
    }

    [HttpDelete("{id:int}")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        var r = await service.DeleteAsync(id, ct);
        return r.Succeeded ? NoContent() : BadRequest(new { error = r.Error });
    }
}
