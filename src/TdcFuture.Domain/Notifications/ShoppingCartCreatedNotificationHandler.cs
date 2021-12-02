using Liquid.Domain.Extensions.Crud.Notifications.GenericEntityAdded;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TdcFuture.Domain.Entities;
using Liquid.Messaging.Interfaces;
using System.Collections.Generic;

namespace TdcFuture.Domain.Notifications.ShoppingCartCreated
{
    public class ShoppingCartCreatedNotificationHandler : INotificationHandler<GenericEntityAddedNotification<ShoppingCart, int>>
    {
        private readonly ILiquidProducer<ShoppingCart> _producer;

        public ShoppingCartCreatedNotificationHandler(ILiquidProducer<ShoppingCart> producer)
        {
            _producer = producer;
        }

        public async Task Handle(GenericEntityAddedNotification<ShoppingCart, int> notification, CancellationToken cancellationToken)
        {
            var customProperties = new Dictionary<string, object>()
            {
                { "EventType", "Created" },
                { "ShoppingCartId", notification.Id },
                { "DataEntity", notification.EntityName }
            };

            await _producer.SendMessageAsync(notification.Data, customProperties);
        }
    }
}
