using Lab13_RamiroSuico.Domain.Models;
using Lab13_RamiroSuico.Domain.Interfaces;
using Lab13_RamiroSuico.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Lab13_RamiroSuico.Infrastructure.Persistence.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly LinqexampleContext _context;

        public ClientRepository(LinqexampleContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _context.Clients.ToListAsync();
        }
    }
}
