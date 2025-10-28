using OnionArchitectureWebAPI.Application.Interfaces.Repositories;
using OnionArchitectureWebAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureWebAPI.Application.Interfaces.UnitofWorks
{
    public interface IUnitofWork : IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : class, IEntityBase, new();
        IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase, new();
        Task<int> SaveChangesAsync();
        int Save();
    }
}
