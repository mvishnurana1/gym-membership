using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;
using MediatR;

namespace GymManagement.Application.Queries.GetSubscription
{
    public record GetSubscriptionQuery(Guid subscriptionId)
        : IRequest<ErrorOr<Subscription>>;

    public class GetSubscriptionQueryHandler : IRequestHandler<GetSubscriptionQuery, ErrorOr<Subscription>>
    {
        private readonly ISubscriptionRepository _subscriptionsRepository;

        public GetSubscriptionQueryHandler(
        ISubscriptionRepository subscriptionsRepository
        )
        {
            _subscriptionsRepository = subscriptionsRepository;
        }

        public async Task<ErrorOr<Subscription>> Handle(GetSubscriptionQuery query, CancellationToken token)
        {
            var subscription = await _subscriptionsRepository.GetAsync(query.subscriptionId);

            return subscription is null
                ? Error.NotFound(description: "Subscription not found")
                : subscription;
        }
    }
}
