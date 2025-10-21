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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Title).IsRequired().HasMaxLength(256);
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.Discount).IsRequired();
            builder.Property(p => p.BrandId).IsRequired();
            builder.Property(p => p.Description).IsRequired().HasMaxLength(512);

            //Seed data
            Faker faker = new("tr");

            var products = Enumerable.Range(1, 50).Select(i =>
                    new Product
                    {
                        Id = i,
                        Title = faker.Commerce.ProductName(),
                        Description = faker.Commerce.ProductDescription(),
                        BrandId = faker.Random.Int(1, 10),
                        Price = decimal.Parse(faker.Commerce.Price(500, 10000)),
                        Discount = decimal.Parse(faker.Commerce.Price(0, 300)),
                        CreatedDate = DateTime.Now,
                        IsDeleted = false
                    }).ToList();

            var deletedProducts = Enumerable.Range(51, 20).Select(i =>
                    new Product
                    {
                        Id = i,
                        Title = faker.Commerce.ProductName(),
                        Description = faker.Commerce.ProductDescription(),
                        BrandId = faker.Random.Int(1, 10),
                        Price = decimal.Parse(faker.Commerce.Price(100, 10000)),
                        Discount = decimal.Parse(faker.Commerce.Price(0, 300)),
                        CreatedDate = DateTime.Now,
                        IsDeleted = true
                    }).ToList();

            builder.HasData(products.Concat(deletedProducts));
        }
    }
}
