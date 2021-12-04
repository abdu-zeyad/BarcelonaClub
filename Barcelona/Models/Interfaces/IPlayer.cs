using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barcelona.Models.Interfaces
{
    public interface IPlayer
    {
        Task<Player> GetPlayer(int Id);
        Task<List<Player>> GetPlayers();
        Task<Player> CreatePlayer(Player player);
        Task<Player> UpdatePlayer(int Id,Player player);
        Task DeletePlayer(int Id);
    }
}
