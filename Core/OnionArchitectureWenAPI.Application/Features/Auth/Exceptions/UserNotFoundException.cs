using OnionArchitectureWebAPI.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureWebAPI.Application.Features.Auth.Exceptions
{
    public class UserNotFoundException : BaseException
    {
        public UserNotFoundException() : base("Kullanıcı bulunamadı")
        {
        }
    }
}
