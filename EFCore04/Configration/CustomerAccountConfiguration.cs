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
    public class CustomerAccountConfiguration : IEntityTypeConfiguration<CustomerAccount>
    {
        public void Configure(EntityTypeBuilder<CustomerAccount> builder)
        {
            builder.HasKey(ca => new { ca.CustomerId, ca.AccountNumber });

            builder.HasOne(ca => ca.Customer)
                   .WithMany(c => c.CustomerAccounts)
                   .HasForeignKey(ca => ca.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ca => ca.Account)
                   .WithMany(a => a.CustomerAccounts)
                   .HasForeignKey(ca => ca.AccountNumber)
                   .OnDelete(DeleteBehavior.Cascade);



            builder.HasData(
    new CustomerAccount
    {
        CustomerId = 1,
        AccountNumber = "12356",
        OwnershipType = OwnershipType.Primary,
        OwnershipStartDate = new DateTime(2025, 1, 10),
        AccountStatus = AccountStatus.Active
    },
    new CustomerAccount
    {
        CustomerId = 2,
        AccountNumber = "12356",
        OwnershipType = OwnershipType.CoHolder,
        OwnershipStartDate = new DateTime(2025, 1, 10),
        AccountStatus = AccountStatus.Active
    },
    new CustomerAccount
    {
        CustomerId = 2,
        AccountNumber = "12357",
        OwnershipType = OwnershipType.Primary,
        OwnershipStartDate = new DateTime(2025, 2, 15),
        AccountStatus = AccountStatus.Active
    },
    new CustomerAccount
    {
        CustomerId = 3,
        AccountNumber = "12358",
        OwnershipType = OwnershipType.Primary,
        OwnershipStartDate = new DateTime(2025, 3, 20),
        AccountStatus = AccountStatus.Active
    },
    new CustomerAccount
    {
        CustomerId = 3,
        AccountNumber = "12356",
        OwnershipType = OwnershipType.CoHolder,
        OwnershipStartDate = new DateTime(2025, 1, 10),
        AccountStatus = AccountStatus.Active
    },
    new CustomerAccount
    {
        CustomerId = 4,
        AccountNumber = "12359",
        OwnershipType = OwnershipType.Primary,
        OwnershipStartDate = new DateTime(2025, 4, 5),
        AccountStatus = AccountStatus.Active
    },
    new CustomerAccount
    {
        CustomerId = 5,
        AccountNumber = "12360",
        OwnershipType = OwnershipType.Primary,
        OwnershipStartDate = new DateTime(2025, 5, 10),
        AccountStatus = AccountStatus.Closed
    }
);



        }
    }
}
