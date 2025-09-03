using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

/// <summary>
/// Carga datos iniciales (Admin por defecto) si la DB está vacía.
/// </summary>
public static class SeedData
{
    public static async Task RunAsync(AppDbContext db)
    {
        // Aplica migraciones pendientes al inicio (útil en dev)
        await db.Database.MigrateAsync();

        // Si no hay usuarios, creamos un Admin
        if (!await db.Users.AnyAsync())
        {
            db.Users.Add(new User
            {
                Email = "admin@admin.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin"),
                FullName = "admin",
                Role = "Admin",
                Active = true
            });

            await db.SaveChangesAsync();
        }
    }
}
