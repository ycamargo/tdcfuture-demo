using Liquid.Domain.Extensions.Crud.Notifications.GenericEntityUpdated;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TdcFuture.Domain.Entities;
using Liquid.Messaging.Interfaces;
using System.Collections.Generic;

namespace TdcFuture.Domain.Notifications.ShoppingCartCreated
{
    public class ShoppingCartUpdatedNotificationHandler : INotificationHandler<GenericEntityUpdatedNotification<ShoppingCart, int>>
    {
        private readonly ILiquidProducer<ShoppingCart> _producer;
        public ShoppingCartUpdatedNotificationHandler(ILiquidProducer<ShoppingCart> producer)
        {
            _producer = producer;
        }

        public async Task Handle(GenericEntityUpdatedNotification<ShoppingCart, int> notification, CancellationToken cancellationToken)
        {
            var customProperties = new Dictionary<string, object>()
            {
                { "EventType", "Updated" },
                { "ShoppingCartId", notification.Id },
                { "DataEntity", notification.EntityName }
            };

            await _producer.SendMessageAsync(notification.Data, customProperties);
        }
    }
}
