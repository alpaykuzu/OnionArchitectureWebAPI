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
    public class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            builder.Property(d => d.Title).IsRequired().HasMaxLength(256);
            builder.Property(d => d.Description).IsRequired().HasMaxLength(512);
            builder.Property(d => d.CategoryId).IsRequired();

            // Seed Data
            Faker faker = new("tr");    
            builder.HasData(
                Enumerable.Range(1, 20).Select(i =>
                    new Detail
                    {
                        Id = i,
                        Title = faker.Lorem.Sentence(1),
                        Description = faker.Lorem.Sentence(5),
                        CategoryId = faker.Random.Int(1, 4),
                        CreatedDate = DateTime.Now,
                        IsDeleted = false
                    }).ToList(),
                Enumerable.Range(20, 30).Select(i =>
                    new Detail
                    {
                        Id = i,
                        Title = faker.Lorem.Sentence(1),
                        Description = faker.Lorem.Sentence(5),
                        CategoryId = faker.Random.Int(1, 4),
                        CreatedDate = DateTime.Now,
                        IsDeleted = true
                    }).ToList()
            );
        }
    }
}
