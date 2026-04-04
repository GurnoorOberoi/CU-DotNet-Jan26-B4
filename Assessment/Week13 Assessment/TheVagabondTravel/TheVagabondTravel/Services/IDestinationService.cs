using TheVagabondTravel.Models;

namespace TheVagabondTravel.Services
{
    public interface IDestinationService
    {
        Task<IEnumerable<Destination>> GetAllAsync();
        Task<Destination> GetByIdAsync(int id);
        Task AddAsync(Destination destination);
        Task UpdateAsync(Destination destination);
        Task DeleteAsync(int id);
    }
}
