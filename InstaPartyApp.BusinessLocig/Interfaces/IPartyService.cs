namespace InstaPartyApp.BusinessLogic.Interfaces
{
    using InstaPartyApp.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPartyService
    {
        Task<IEnumerable<Party>> GetAllPartiesAsync();
        Task<Party> GetPartyByIdAsync(int id);
        Task CreatePartyAsync(Party party);
        Task UpdatePartyAsync(Party party);
        Task DeletePartyAsync(int id);
    }
}