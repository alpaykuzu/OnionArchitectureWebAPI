using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArchitectureWebAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureWebAPI.Persistance.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.ParentId).IsRequired();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(256);
            builder.Property(c => c.Priorty).IsRequired();

            // Seed Data
            builder.HasData(
                new Category
                {
                    Id = 1,
                    ParentId = 0,
                    Name = "Elektrik",
                    Priorty = 1,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                },
                new Category
                {
                    Id = 2,
                    ParentId = 0,
                    Name = "Moda",
                    Priorty = 2,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                },
                new Category
                {
                    Id = 3,
                    ParentId = 1,
                    Name = "Bilgisayar",
                    Priorty = 1,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                },
                new Category
                {
                    Id = 4,
                    ParentId = 2,
                    Name = "kadın",
                    Priorty = 1,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                }
            );
        }
    }
}
