using Microsoft.EntityFrameworkCore;
using TheVagabondTravel.Data;
using TheVagabondTravel.Exceptions;
using TheVagabondTravel.Models;

namespace TheVagabondTravel.Repositories
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly TheVagabondTravelContext _context;
        public DestinationRepository(TheVagabondTravelContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Destination>> GetAllAsync()
        {
            return await _context.Destination.ToListAsync();
        }
        public async Task<Destination> GetByIdAsync(int id)
        {
            var destination = await _context.Destination.FindAsync(id);
            if (destination == null)
            {
                throw new DestinationNotFoundException($"Destination with id {id} not found.");
            }
            return destination;
        }
        public async Task AddAsync(Destination destination)
        {
            _context.Destination.Add(destination);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Destination destination)
        {
            _context.Entry(destination).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var destination = await _context.Destination.FindAsync(id);
            if (destination == null)
            {
                throw new DestinationNotFoundException($"Destination with id {id} not found.");
            }
            _context.Destination.Remove(destination);
            await _context.SaveChangesAsync();
        }
    }
}
