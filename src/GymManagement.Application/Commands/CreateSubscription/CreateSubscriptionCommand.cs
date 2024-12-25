using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;
using MediatR;

namespace GymManagement.Application.Commands.CreateSubscription
{
    public record CreateSubscriptionCommand(
        string SubscriptionType,
        Guid AdminId) : IRequest<ErrorOr<Subscription>>;

    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, ErrorOr<Subscription>>
    {
        private readonly ISubscriptionRepository _subscriptionsRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateSubscriptionCommandHandler(
            ISubscriptionRepository subscriptionsRepository,
            IUnitOfWork unitOfWork)
        {
            _subscriptionsRepository = subscriptionsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Subscription>> Handle(CreateSubscriptionCommand request, CancellationToken token)
        {
            var subs = new Subscription
            {
                Id = Guid.NewGuid(),
            };

            await _subscriptionsRepository.AddSubscriptionAsync(subs);
            await _unitOfWork.CommitChangesAsync();

            return subs;
        }
    }
}
