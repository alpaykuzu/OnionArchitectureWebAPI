using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureWebAPI.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .MaximumLength(100)
                .WithName("Başlık");

            RuleFor(p => p.Description)
                .NotEmpty()
                .MaximumLength(500)
                .WithName("Açıklama");

            RuleFor(p => p.Price)
                .NotEmpty()
                .GreaterThan(0)
                .WithName("Fiyat");

            RuleFor(p => p.Discount)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(100)
                .WithName("İndirim Yüzdesi");

            RuleFor(p => p.CategoryIds)
                .NotEmpty()
                .Must(ids => ids.All(id => id > 0))
                .WithName("Kategori");

            RuleFor(p => p.BrandId)
                .NotEmpty()
                .GreaterThan(0)
                .WithName("Marka");
        }
    }
}
