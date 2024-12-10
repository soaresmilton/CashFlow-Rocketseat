using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess;
internal class CashFlowDbContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=localhost;Database=db_cashflow;Uid=root;Pwd=@Password123";
        var version = new Version(8, 0, 45);
        var serverVersion = new MySqlServerVersion(version);
        optionsBuilder.UseMySql(connectionString, serverVersion);
    }
}
