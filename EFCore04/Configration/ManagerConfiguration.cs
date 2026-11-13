using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore04.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace EFCore04.Configration
{
    

 

    public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.Property(m => m.FullName).HasMaxLength(100).IsRequired();
            builder.Property(m => m.Email).HasMaxLength(150).IsRequired();
            builder.Property(m => m.PhoneNumber).HasMaxLength(20);

            builder.HasData(
                new Manager { Id = 1, FullName = "Hassan Mahmoud", Email = "hassan@nbg.com", PhoneNumber = "01000000001", HireDate = new DateTime(2018, 3, 1) },
                new Manager { Id = 2, FullName = "Salma Adel", Email = "salma@nbg.com", PhoneNumber = "01000000002", HireDate = new DateTime(2020, 7, 15) });
        }
    }
}
