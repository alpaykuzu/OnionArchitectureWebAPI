using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureWebAPI.Application.Features.Auth.Exceptions
{
    public class EmailOrPasswordWrongException : Exception
    {
        public EmailOrPasswordWrongException() : base("Email ya da şifre yanlış.")
        {
        }
    }
}
