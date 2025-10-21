using Bogus;
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
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(b => b.Name).IsRequired().HasMaxLength(256);

            // Seed Data
            Faker faker = new("tr");
            var brands = Enumerable.Range(1, 10).Select(i =>
                new Brand
                {
                    Id = i,
                    Name = faker.Company.CompanyName(),
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                }).ToList();
            var deletedBrands = Enumerable.Range(10, 15).Select(i =>
                new Brand
                {
                    Id = i,
                    Name = faker.Company.CompanyName(),
                    CreatedDate = DateTime.Now,
                    IsDeleted = true
                }).ToList();
            builder.HasData(brands, deletedBrands);
        }
    }
}
