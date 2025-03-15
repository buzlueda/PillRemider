using System.Reflection;
using CorePackages.Infrastructure.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using PillReminder.Core.Domain.Entities;

namespace PillReminder.Infrastructure.Persistence.Contexts;

public class PillReminderDbContext : DbContext
{
    protected IConfiguration Configuration { get; set;}
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;
    public DbSet<OperationClaim> OperationClaims { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Medication> Medications { get; set; } = null!;
    public DbSet<Reminder> Reminders { get; set; } = null!;
    public DbSet<Unit> Units { get; set; } = null!;
    
    public PillReminderDbContext(DbContextOptions<PillReminderDbContext> options, IConfiguration configuration) : base(options)
    {
        Configuration = configuration;

    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        IEnumerable<EntityEntry<BaseEntity<Guid>>> entries = ChangeTracker
            .Entries<BaseEntity<Guid>>()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        foreach (EntityEntry<BaseEntity<Guid>> entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.ModifiedAt = DateTime.UtcNow;
                    break;
                case EntityState.Deleted:
                    entry.Entity.DeletedAt = DateTime.UtcNow;
                    entry.State = EntityState.Modified;
                    break;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}