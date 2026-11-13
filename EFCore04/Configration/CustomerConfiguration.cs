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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.FullName).HasMaxLength(100).IsRequired();
            builder.Property(c => c.NationalId).HasMaxLength(20).IsRequired();
            builder.HasIndex(c => c.NationalId).IsUnique();
            builder.Property(c => c.Email).HasMaxLength(150);
            builder.Property(c => c.PhoneNumber).HasMaxLength(20);



            builder.HasData(
                new Customer
                {
                    Id = 2,
                    FullName = "Sara Ali",
                    NationalId = "29502021234567",
                    DateOfBirth = new DateTime(1995, 2, 2),
                    Email = "sara@gmail.com",
                    PhoneNumber = "01023456789",
                    Address = "Giza",
                    CustomerType = CustomerType.Individual
                },
                new Customer
                {
                    Id = 3,
                    FullName = "Omar Hassan",
                    NationalId = "28803031234567",
                    DateOfBirth = new DateTime(1988, 3, 3),
                    Email = "omar@gmail.com",
                    PhoneNumber = "01034567890",
                    Address = "Alexandria",
                    CustomerType = CustomerType.Individual
                },
                new Customer
                {
                    Id = 4,
                    FullName = "ABC Company",
                    NationalId = "12345678901234",
                    DateOfBirth = new DateTime(2000, 1, 1),
                    Email = "abc@company.com",
                    PhoneNumber = "01045678901",
                    Address = "Cairo",
                    CustomerType = CustomerType.Business
                },
                new Customer
                {
                    Id = 5,
                    FullName = "Mona Samir",
                    NationalId = "29805051234567",
                    DateOfBirth = new DateTime(1998, 5, 5),
                    Email = "mona2@gmail.com",
                    PhoneNumber = "01056789012",
                    Address = "Giza",
                    CustomerType = CustomerType.Individual
                }
            );
        }
    }
}
