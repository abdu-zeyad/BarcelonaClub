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
        public async Task<Venue> CreateVenue(Venue venue)
        {
            _context.Entry(venue).State = EntityState.Added;
           await _context.SaveChangesAsync();
            return venue;
        }

        public async Task DeleteVenue(int Id)
        {
            var venue = GetVenue(Id);
            _context.Entry(venue).State= EntityState.Deleted;
            await _context.SaveChangesAsync();
            
        }

        public async Task<Venue> GetVenue(int Id)
        {
            return await _context.Venues.Include(v => v.Sport).FirstOrDefaultAsync(s => s.Id == Id);
        }

        public async Task<List<Venue>> GetVenues()
        {
            return await _context.Venues.Include(v => v.Sport).ToListAsync();
        }

        public async Task<Venue> UpdateVenue(int Id, Venue venue)
        {
            _context.Entry(venue).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return venue;
            
        }
    }
}
