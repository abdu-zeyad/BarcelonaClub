using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barcelona.Models.Interfaces
{
    public interface IVenue
    {
        Task<Venue> GetVenue(int Id);
        Task<List<Venue>> GetVenues();
        Task<Venue> CreateVenue(Venue venue);
        Task<Venue> UpdateVenue(int Id, Venue venue);
        Task DeleteVenue(int Id);

    }
}
