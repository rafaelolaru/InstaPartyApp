using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class PartyRepository : IPartyRepository
    {
        private readonly AppDbContext _context;

        public PartyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Party>> GetAllParties()
        {
            return await _context.Parties.ToListAsync();
        }

        public async Task<Party> GetPartyById(int id)
        {
            var party = await _context.Parties.FindAsync(id);
            if (party == null)
            {
                throw new System.NullReferenceException("Party not found.");
            }
            return party;
        }


        public async Task CreateParty(Party party)
        {
            _context.Parties.Add(party);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateParty(Party party)
        {
            _context.Entry(party).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteParty(int id)
        {
            var party = await _context.Parties.FindAsync(id);
            if (party != null)
            {
                _context.Parties.Remove(party);
                await _context.SaveChangesAsync();
            }
        }
    }
}