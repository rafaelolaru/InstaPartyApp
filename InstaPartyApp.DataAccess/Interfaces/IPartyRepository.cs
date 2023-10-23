using InstaPartyApp.Models;

namespace InstaPartyApp.DataAccess.Interfaces
{
    public interface IPartyRepository
    {
        Task<IEnumerable<Party>> GetAllParties();
        Task<Party> GetPartyById(int id);
        Task CreateParty(Party party);
        Task UpdateParty(Party party);
        Task DeleteParty(int id);
    }
}
