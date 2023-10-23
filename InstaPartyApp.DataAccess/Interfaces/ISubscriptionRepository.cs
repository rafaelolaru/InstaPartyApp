using InstaPartyApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstaPartyApp.DataAccess.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<Subscription>> GetAllSubscriptions();
        Task<Subscription> GetSubscriptionById(int id);
        Task CreateSubscription(Subscription subscription);
        Task UpdateSubscription(Subscription subscription);
        Task DeleteSubscription(int id);
    }
}