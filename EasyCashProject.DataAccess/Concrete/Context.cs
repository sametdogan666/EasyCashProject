using EasyCashProject.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyCashProject.DataAccess.Concrete;

public class Context : IdentityDbContext<AppUser, AppRole, int>
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-LVPTDQG\SQLEXPRESS; initial catalog= EasyCashDb; integrated security = true");
    }

    public DbSet<CustomerAccount>? CustomerAccounts { get; set; }
    public DbSet<CustomerAccountProcess>? CustomerAccountProcesses { get; set; }
    

}