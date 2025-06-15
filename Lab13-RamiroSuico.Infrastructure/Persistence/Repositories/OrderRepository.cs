
using Lab13_RamiroSuico.Domain.Models;
using Lab13_RamiroSuico.Infrastructure.Context;
using IOrderRepository = Lab13_RamiroSuico.Domain.Interfaces.IOrderRepository;

namespace Lab13_RamiroSuico.Infrastructure.Persistence.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(LinqexampleContext context) : base(context)
        {
        }
    }
}