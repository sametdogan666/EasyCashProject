﻿using EasyCashProject.Entities.Concrete;
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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<CustomerAccountProcess>()
            .HasOne(x => x.SenderCustomer)
            .WithMany(y => y.CustomerSender)
            .HasForeignKey(z => z.SenderId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.Entity<CustomerAccountProcess>()
            .HasOne(x => x.ReceiverCustomer)
            .WithMany(y => y.CustomerReceiver)
            .HasForeignKey(z => z.ReceiverId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        base.OnModelCreating(builder);
    }
}