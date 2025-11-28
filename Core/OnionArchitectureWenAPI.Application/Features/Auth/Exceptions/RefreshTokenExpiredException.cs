using OnionArchitectureWebAPI.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureWebAPI.Application.Features.Auth.Exceptions
{
    public class RefreshTokenExpiredException : BaseException
    {
        public RefreshTokenExpiredException() : base("Oturum sonlandırıldı. Lütfen giriş yapın!")
        {
        }
    }
}
