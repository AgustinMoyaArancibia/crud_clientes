using Application.Common.Paging;
using Application.Common.Results;
using Application.Features.Clients.Mappers;
using Application.Features.Clients.Models;
using Application.Features.Clients.Services;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ClientService : IClientService
{
    private readonly AppDbContext _db;

    public ClientService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<PagedResult<ClientReadDto>> GetAsync(PagedRequest request, CancellationToken ct = default)
    {
        var q = _db.Clients.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            var s = request.Search.Trim();
            q = q.Where(x => x.Name.Contains(s) || x.Dni.Contains(s));
        }

        var total = await q.CountAsync(ct);
        var items = await q
            .OrderBy(x => x.Id)
            .Skip((request.PageSafe - 1) * request.SizeSafe)
            .Take(request.SizeSafe)
            .Select(x => x.ToReadDto())
            .ToListAsync(ct);

        return new PagedResult<ClientReadDto>
        {
            Items = items,
            Total = total,
            Page = request.PageSafe,
            Size = request.SizeSafe
        };
    }

    public async Task<Result<ClientReadDto>> GetByIdAsync(int id, CancellationToken ct = default)
    {
        var e = await _db.Clients.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, ct);
        return e is null
            ? Result<ClientReadDto>.Failure("Cliente no encontrado")
            : Result<ClientReadDto>.Success(e.ToReadDto());
    }

    public async Task<Result<int>> CreateAsync(ClientCreateDto dto, CancellationToken ct = default)
    {
        if (await _db.Clients.AnyAsync(c => c.Dni == dto.Dni, ct))
            return Result<int>.Failure("DNI ya registrado");

        var e = new Client
        {
            Dni = dto.Dni,
            Name = dto.Name,
            ShippingAddres = dto.ShippingAddress,
            Active = true
        };

        _db.Clients.Add(e);
        await _db.SaveChangesAsync(ct);

        return Result<int>.Success(e.Id);
    }

    public async Task<Result<bool>> UpdateAsync(int id, ClientUpdateDto dto, CancellationToken ct = default)
    {
        var e = await _db.Clients.FirstOrDefaultAsync(x => x.Id == id, ct);
        if (e is null) return Result<bool>.Failure("Cliente no encontrado");

        e.Name = dto.Name;
        e.ShippingAddres = dto.ShippingAddress;
        e.Active = dto.Active;

        await _db.SaveChangesAsync(ct);
        return Result<bool>.Success(true);
    }

    public async Task<Result<bool>> DeleteAsync(int id, CancellationToken ct = default)
    {
        var e = await _db.Clients.FirstOrDefaultAsync(x => x.Id == id, ct);
        if (e is null) return Result<bool>.Failure("Cliente no encontrado");

        _db.Clients.Remove(e);
        await _db.SaveChangesAsync(ct);

        return Result<bool>.Success(true);
    }
}
