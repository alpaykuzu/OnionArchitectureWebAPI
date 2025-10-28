using Microsoft.EntityFrameworkCore;
using OnionArchitectureWebAPI.Application.Interfaces.Repositories;
using OnionArchitectureWebAPI.Application.Interfaces.UnitofWorks;
using OnionArchitectureWebAPI.Persistance.Context;
using OnionArchitectureWebAPI.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureWebAPI.Persistance.UnitofWorks
{
    internal class UnitofWork : IUnitofWork
    {
        private readonly AppDbContext _context;

        public UnitofWork(AppDbContext context)
        {
            _context = context;
        }

        public async ValueTask DisposeAsync() => await _context.DisposeAsync();

        public int Save() => _context.SaveChanges();

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        IReadRepository<T> IUnitofWork.GetReadRepository<T>() => new ReadRepository<T>(_context);

        IWriteRepository<T> IUnitofWork.GetWriteRepository<T>() => new WriteRepository<T>(_context);
    }
}
