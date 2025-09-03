using Application.Common.Paging;
using Application.Common.Results;
using Application.Features.Users.Mappers;
using Application.Features.Users.Models;
using Application.Features.Users.Services;
using BCrypt.Net;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Services;

public class UserService(AppDbContext db) : IUserService
{
    public async Task<PagedResult<UserReadDto>> GetAsync(PagedRequest request, CancellationToken ct = default)
    {
        var q = db.Users.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            var s = request.Search.Trim();
            q = q.Where(x => x.Email.Contains(s) || x.FullName.Contains(s));
        }

        var total = await q.CountAsync(ct);
        var items = await q
            .OrderBy(x => x.Id)
            .Skip((request.PageSafe - 1) * request.SizeSafe)
            .Take(request.SizeSafe)
            .Select(x => x.ToReadDto())
            .ToListAsync(ct);

        return new PagedResult<UserReadDto>
        {
            Items = items,
            Total = total,
            Page = request.PageSafe,
            Size = request.SizeSafe
        };
    }

    public async Task<Result<UserReadDto>> GetByIdAsync(int id, CancellationToken ct = default)
    {
        var e = await db.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, ct);
        return e is null
            ? Result<UserReadDto>.Failure("Usuario no encontrado")
            : Result<UserReadDto>.Success(e.ToReadDto());
    }

    public async Task<Result<int>> CreateAsync(UserCreateDto dto, CancellationToken ct = default)
    {
        if (await db.Users.AnyAsync(u => u.Email == dto.Email, ct))
            return Result<int>.Failure("Email ya registrado");

        var e = new User
        {
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            FullName = dto.FullName,
            Role = dto.Role
        };
        db.Users.Add(e);
        await db.SaveChangesAsync(ct);
        return Result<int>.Success(e.Id);
    }

    public async Task<Result<bool>> UpdateAsync(int id, UserUpdateDto dto, CancellationToken ct = default)
    {
        var e = await db.Users.FirstOrDefaultAsync(x => x.Id == id, ct);
        if (e is null) return Result<bool>.Failure("Usuario no encontrado");

        e.FullName = dto.FullName;
        e.Role = dto.Role;
        e.Active = dto.Active;

        await db.SaveChangesAsync(ct);
        return Result<bool>.Success(true);
    }

    public async Task<Result<bool>> DeleteAsync(int id, CancellationToken ct = default)
    {
        var e = await db.Users.FirstOrDefaultAsync(x => x.Id == id, ct);
        if (e is null) return Result<bool>.Failure("Usuario no encontrado");

        db.Users.Remove(e);
        await db.SaveChangesAsync(ct);
        return Result<bool>.Success(true);
    }
}
