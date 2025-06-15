using Lab13_RamiroSuico.Domain.Models;
namespace Lab13_RamiroSuico.Domain.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllAsync();
    }
}