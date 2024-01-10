using DataAccessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
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