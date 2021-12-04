using Barcelona.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barcelona.Models.Services
{
    public class PlayerService : IPlayer
    {
        public Task<Player> CreatePlayer(Player player)
        {
            throw new System.NotImplementedException();
        }

        public Task DeletePlayer(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Player> GetPlayer(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Player>> GetPlayers()
        {
            throw new System.NotImplementedException();
        }

        public Task<Player> UpdatePlayer(int Id, Player player)
        {
            throw new System.NotImplementedException();
        }
    }
}
