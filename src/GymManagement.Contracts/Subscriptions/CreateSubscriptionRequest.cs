﻿namespace GymManagement.Contracts.Subscriptions
{
    public record CreateSubscriptionRequest(SubscriptionType subscriptionType, Guid AdminId);
}
