using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalLifeOS.Domain.Finance;
using PersonalLifeOS.Domain.Users;
using PersonalLifeOS.Infrastructure.Identity;

namespace PersonalLifeOS.Infrastructure.Persistence;

public class FinanceDbContext : IdentityDbContext<ApplicationUser>
{
    public FinanceDbContext(DbContextOptions<FinanceDbContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; } = null!;

    public DbSet<Transaction> Transactions { get; set; } = null!;

    public DbSet<UserPreference> UserPreferences { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Identity configures its tables and keys here before our custom mappings.
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>()
            .Property(category => category.CategoryName)
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<Category>()
            .Property(category => category.Description)
            .HasMaxLength(500);

        modelBuilder.Entity<Transaction>()
            .Property(transaction => transaction.Title)
            .HasMaxLength(200)
            .IsRequired();

        modelBuilder.Entity<Transaction>()
            .Property(transaction => transaction.Amount)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Transaction>()
            .HasOne(transaction => transaction.Category)
            .WithMany(category => category.Transactions)
            .HasForeignKey(transaction => transaction.CategoryId);

        ConfigureIdentityUser(modelBuilder);
        ConfigureUserPreference(modelBuilder);
    }

    private static void ConfigureIdentityUser(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationUser>()
            .Property(user => user.DisplayName)
            .HasMaxLength(100)
            .IsRequired();
    }

    private static void ConfigureUserPreference(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserPreference>()
            .Property(preference => preference.Currency)
            .HasMaxLength(3)
            .HasDefaultValue("VND")
            .IsRequired();

        modelBuilder.Entity<UserPreference>()
            .Property(preference => preference.TimeZone)
            .HasMaxLength(100)
            .HasDefaultValue("Asia/Ho_Chi_Minh")
            .IsRequired();

        modelBuilder.Entity<UserPreference>()
            .HasOne<ApplicationUser>()
            .WithOne()
            .HasForeignKey<UserPreference>(preference => preference.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserPreference>()
            .HasIndex(preference => preference.UserId)
            .IsUnique();
    }
}
