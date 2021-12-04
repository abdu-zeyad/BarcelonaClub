using Barcelona.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barcelona.Models.Services
{
    public class SportService : ISport
    {
        public Task<Sport> CreateSport(Sport sport)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteSport(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Sport> GetSport(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Sport>> GetSports()
        {
            throw new System.NotImplementedException();
        }

        public Task<Sport> UpdateSport(Sport sport)
        {
            throw new System.NotImplementedException();
        }
    }
}
