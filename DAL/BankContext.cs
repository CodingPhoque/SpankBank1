namespace SpankBank1.DAL;  
using Microsoft.EntityFrameworkCore;
using SpankBank1.Models;

public class BankContext : DbContext
{
    public DbSet<Account> BankAccounts { get; set; }

    public BankContext(DbContextOptions<BankContext> options) : base(options)
    {
    }
}

