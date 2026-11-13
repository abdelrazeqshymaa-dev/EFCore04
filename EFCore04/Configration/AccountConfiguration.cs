using EFCore04.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore04.Configration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.AccountNumber);
            builder.Property(a => a.AccountNumber).HasMaxLength(20);
            builder.Property(a => a.CurrentBalance).HasColumnType("decimal(18,2)");

            builder.HasOne(a => a.Branch)
                   .WithMany(b => b.Accounts)
                   .HasForeignKey(a => a.BranchId)
                   .OnDelete(DeleteBehavior.Restrict);



            builder.HasData(
    new Account
    {
        AccountNumber = "12356",
        AccountType = AccountType.Savings,
        CurrentBalance = 15000,
        OpeningDate = new DateTime(2025, 1, 10),
        BranchId = 1
    },
    new Account
    {
        AccountNumber = "12357",
        AccountType = AccountType.Current,
        CurrentBalance = 25000,
        OpeningDate = new DateTime(2025, 2, 15),
        BranchId = 1
    },
    new Account
    {
        AccountNumber = "12358",
        AccountType = AccountType.Savings,
        CurrentBalance = 10000,
        OpeningDate = new DateTime(2025, 3, 20),
        BranchId = 2
    },
    new Account
    {
        AccountNumber = "12359",
        AccountType = AccountType.Business,
        CurrentBalance = 100000,
        OpeningDate = new DateTime(2025, 4, 5),
        BranchId = 2
    },
    new Account
    {
        AccountNumber = "12360",
        AccountType = AccountType.Current,
        CurrentBalance = 5000,
        OpeningDate = new DateTime(2025, 5, 10),
        BranchId = 1
    },
    new Account
    {
        AccountNumber = "12361",
        AccountType = AccountType.Savings,
        CurrentBalance = 3000,
        OpeningDate = new DateTime(2025, 6, 1),
        BranchId = 2
    }
);



        }
    }
}
