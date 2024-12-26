using MediatR;
using GymManagement.Contracts.Subscriptions;
using Microsoft.AspNetCore.Mvc;
using GymManagement.Application.Commands.CreateSubscription;
using GymManagement.Domain.Subscriptions;
using GymManagement.Application.Queries.GetSubscription;

namespace GymManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISender _mediator;
        public SubscriptionsController(
            ISender mediator
        )
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscription(CreateSubscriptionRequest request)
        {
            var command = new CreateSubscriptionCommand(
                    request.subscriptionType.ToString(),
                    request.AdminId
            );

            var createSubscriptionResult = await _mediator.Send(command);

            return createSubscriptionResult.MatchFirst(
                subscription => Ok(new SubscriptionResponse(subscription.Id, request.subscriptionType)),
                error => Problem()
            );
        }

        [HttpGet("{subscriptionId:guid}")]
        public async Task<IActionResult> Get(Guid subscriptionId)
        {
            var query = new GetSubscriptionQuery(subscriptionId);

            var getSubscriptionResult = await _mediator.Send(query);

            return getSubscriptionResult.MatchFirst(
                subscription => Ok(new SubscriptionResponse(
                        subscription.Id,
                        Enum.Parse<SubscriptionType>(subscription.SubscriptionType)
                    )),
                error => Problem()
            );
        }
    }
}
