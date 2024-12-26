using GymManagement.Domain.Subscriptions;

namespace GymManagement.Application.Common.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task AddSubscriptionAsync(Subscription subscription);
        Task<Subscription?> GetAsync(Guid id);
    }

    public interface IUnitOfWork
    {
        Task CommitChangesAsync();
    }
}
