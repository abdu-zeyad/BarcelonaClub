using Barcelona.Data;
using Barcelona.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barcelona.Models.Services
{
    public class VenueService : IVenue
    {
        private BarcelonaDbContext _context;

        public VenueService(BarcelonaDbContext context)
        {
            _context= context;
        }
        public Task<Venue> CreateVenue(Venue venue)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteVenue(int Id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Venue> GetVenue(int Id)
        {
            return await _context.Venues.Include(v => v.Sport).FirstOrDefaultAsync(s => s.Id == Id);
        }

        public async Task<List<Venue>> GetVenues()
        {
            return await _context.Venues.Include(v => v.Sport).ToListAsync();
        }

        public Task<Venue> UpdateVenue(int Id, Venue venue)
        {
            throw new System.NotImplementedException();
        }
    }
}
