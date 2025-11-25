using OnionArchitectureWebAPI.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureWebAPI.Application.Features.Products.Rules
{
    public class ProductRules : BaseRules
    {
        public Task ProductTitleMustNotBeSame(string title, List<string> existingTitles)
        {
            if (existingTitles.Contains(title))
            {
                throw new Exceptions.ProductTitleMustNotBeSameException();
            }
            return Task.CompletedTask;
        }
    }
}
