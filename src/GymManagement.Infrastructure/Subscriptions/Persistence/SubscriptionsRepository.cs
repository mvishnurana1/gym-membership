using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;

namespace GymManagement.Infrastructure.Subscriptions.Persistence
{
    public class SubscriptionsRepository : ISubscriptionRepository
    {
        private readonly static List<Subscription> _subscriptions = new();
        public Task AddSubscriptionAsync(Subscription subscription)
        {
            _subscriptions.Add(subscription);
            return Task.CompletedTask;
        }

        public Task<Subscription> GetAsync(Guid id)
        {
            var subscription = _subscriptions.FirstOrDefault(x => x.Id == id);

            return Task.FromResult(subscription);
        }
    }
}
