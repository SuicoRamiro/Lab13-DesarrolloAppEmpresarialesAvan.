using Lab13_RamiroSuico.Domain.Models;

namespace Lab13_RamiroSuico.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IClientRepository ClientRepository { get; }
        IOrderRepository OrderRepository { get; }

        Task<int> SaveChangesAsync();
    }
}