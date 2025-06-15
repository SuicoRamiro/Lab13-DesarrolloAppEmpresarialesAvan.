using Lab13_RamiroSuico.Domain.Interfaces;
using Lab13_RamiroSuico.Infrastructure.Context;
using Lab13_RamiroSuico.Infrastructure.Persistence.Repositories;

namespace Lab13_RamiroSuico.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LinqexampleContext _context;
        public IClientRepository ClientRepository { get; }
        public IOrderRepository OrderRepository { get; }

        public UnitOfWork(LinqexampleContext context)
        {
            _context = context;
            ClientRepository = new ClientRepository(context);
            OrderRepository = new OrderRepository(context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}