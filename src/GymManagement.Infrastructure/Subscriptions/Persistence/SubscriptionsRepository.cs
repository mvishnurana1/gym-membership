using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;
using GymManagement.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Infrastructure.Subscriptions.Persistence
{
    public class SubscriptionsRepository : ISubscriptionRepository
    {
        private readonly GymManagementDbContext _dbContext;
        public SubscriptionsRepository(GymManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddSubscriptionAsync(Subscription subscription)
        {
            await _dbContext.Subscriptions.AddAsync(subscription);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Subscription?> GetAsync(Guid id)
        {
            var subscription = await _dbContext.Subscriptions.FindAsync(id);

            return subscription;
        }
    }
}
