using InstaPartyApp.BusinessLogic.Interfaces;
using InstaPartyApp.DataAccess.Interfaces;
using InstaPartyApp.Models;

namespace InstaPartyApp.BusinessLogic.Services
{
    public class PartyService : IPartyService
    {
        private readonly IPartyRepository _partyRepository;

        public PartyService(IPartyRepository partyRepository)
        {
            _partyRepository = partyRepository;
        }

        public async Task<IEnumerable<Party>> GetAllPartiesAsync()
        {
            return await _partyRepository.GetAllParties();
        }

        public async Task<Party> GetPartyByIdAsync(int id)
        {
            return await _partyRepository.GetPartyById(id);
        }

        public async Task CreatePartyAsync(Party party)
        {
            await _partyRepository.CreateParty(party);
        }

        public async Task UpdatePartyAsync(Party party)
        {
            await _partyRepository.UpdateParty(party);
        }

        public async Task DeletePartyAsync(int id)
        {
            await _partyRepository.DeleteParty(id);
        }
    }
}