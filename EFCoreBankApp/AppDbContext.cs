using Microsoft.EntityFrameworkCore;

namespace EFCoreBankApp;

public class AppDbContext : DbContext
{
    public DbSet<BankAccount> BankAccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;" +
            "Database=BankDB;" +
            "User Id=sa;" +
            "Password=Re2006@@;"+
            "TrustServerCertificate=True;"
        );
    }
}