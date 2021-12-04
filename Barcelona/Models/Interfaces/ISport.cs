using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barcelona.Models.Interfaces
{
    public interface ISport
    {
        Task<Sport> GetSport(int Id);
        Task<List<Sport>> GetSports();
        Task<Sport> CreateSport(Sport sport);
        Task<Sport>UpdateSport(int Id,Sport sport);
        Task DeleteSport(int Id);

    }
}
