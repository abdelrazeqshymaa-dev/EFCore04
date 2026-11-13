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
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.Property(b => b.Code).HasMaxLength(20).IsRequired();
            builder.HasIndex(b => b.Code).IsUnique();
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();

            builder.HasOne(b => b.Manager)
                   .WithOne(m => m.Branch)
                   .HasForeignKey<Branch>(b => b.ManagerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Branch { Id = 1, Code = "CAI-01", Name = "Cairo Main Branch", Address = "Cairo", PhoneNumber = "0221111111", ManagerId = 1 },
                new Branch { Id = 2, Code = "ALX-01", Name = "Alexandria Branch", Address = "Alexandria", PhoneNumber = "0322222222", ManagerId = 2 });
        }
    }
}
