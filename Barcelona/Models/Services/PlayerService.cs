using Barcelona.Data;
using Barcelona.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barcelona.Models.Services
{
    public class PlayerService : IPlayer
    {
        private BarcelonaDbContext _context;

        public PlayerService(BarcelonaDbContext context)
        {
            _context = context;
        }
        public async Task<Player> CreatePlayer(Player player)
        {
            _context.Entry(player).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task DeletePlayer(int Id)
        {
            var player = GetPlayer(Id);
            _context.Entry(player).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public Task<Player> GetPlayer(int Id)
        {
            var player = _context.Players.FirstOrDefaultAsync(p=>p.Id == Id);
            return player;
        }

        public async Task<List<Player>> GetPlayers()
        {
            return await _context.Players.ToListAsync();
        }

        public async Task<Player> UpdatePlayer(int Id, Player player)
        {
            _context.Entry(player).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return player;
        }
    }
}
