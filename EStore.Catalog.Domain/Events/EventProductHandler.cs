using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EStore.Catalog.Domain.Interfaces;
using MediatR;

namespace EStore.Catalog.Domain.Events
{
    public class EventProductHandler : INotificationHandler<EventProductDropStock>
    {
        private  readonly  IProductRepository _productRepository;

        public EventProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(EventProductDropStock notification, CancellationToken cancellationToken)
        {
            await _productRepository.GetByID(notification.AggregateId);
            
            //TODO: send email
        }
    }
}
