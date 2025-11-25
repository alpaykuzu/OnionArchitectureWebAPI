using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureWebAPI.Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommandRequest>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .GreaterThan(0)
                .WithName("Ürün Id");
        }
    }
}
