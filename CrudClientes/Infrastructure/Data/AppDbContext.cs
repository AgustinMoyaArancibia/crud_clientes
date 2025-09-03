using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Client> Clients => Set<Client>();

    protected override void OnModelCreating(ModelBuilder model)
    {
        base.OnModelCreating(model);

        // === Users ===
        model.Entity<User>(e =>
        {
            e.ToTable("Users");
            e.HasKey(x => x.Id);
            e.HasIndex(x => x.Email).IsUnique();

            e.Property(x => x.Email).HasMaxLength(120).IsRequired();
            e.Property(x => x.PasswordHash).HasMaxLength(200).IsRequired();
            e.Property(x => x.FullName).HasMaxLength(100).IsRequired();
            e.Property(x => x.Role).HasMaxLength(30).IsRequired();
            e.Property(x => x.Active).HasDefaultValue(true);

            // si la entidad tiene CreatedAt, lo mapeamos
            e.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
        });

        // === Clients ===
        model.Entity<Client>(e =>
        {
            e.ToTable("Clients");
            e.HasKey(x => x.Id);
            e.HasIndex(x => x.Dni).IsUnique();

            e.Property(x => x.Dni).HasMaxLength(12).IsRequired();
            e.Property(x => x.Name).HasMaxLength(120).IsRequired();
            e.Property(x => x.ShippingAddres).HasMaxLength(200);
            e.Property(x => x.Active).HasDefaultValue(true);

            // si la entidad tiene CreatedAt, lo mapeamos
            e.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
        });
    }
}
