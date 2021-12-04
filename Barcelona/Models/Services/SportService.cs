using Barcelona.Data;
using Barcelona.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barcelona.Models.Services
{
    public class SportService : ISport
    {
        private BarcelonaDbContext _context;

        public SportService(BarcelonaDbContext context)
        {
            _context = context;
        }
        public async Task<Sport> CreateSport(Sport sport)
        {
            _context.Entry(sport).State= EntityState.Added;
            await _context.SaveChangesAsync();
            return sport;
        }

        public async Task DeleteSport(int Id)
        {
            var sport = GetSport(Id);
            _context.Entry(sport).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            
        }

        public async Task<Sport> GetSport(int Id)
        {
           var sport= await _context.Sports.Include(s => s.Players).FirstOrDefaultAsync(x=>x.Id==Id);
            return sport;
        } 

        public async Task<List<Sport>> GetSports()
        {
            return await _context.Sports.Include(s => s.Players).ToListAsync();
        }

        public async Task<Sport> UpdateSport(int Id, Sport sport)
        {
            _context.Entry(sport).State=EntityState.Modified;
            await _context.SaveChangesAsync();
            return sport;
        }
    }
}
