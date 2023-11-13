using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EStore.Core.DomainObjects;

namespace EStore.Catalog.Domain.Events
{
    public class EventProductDropStock : DomainEvent
    {
        public  int QtyRemaining { get; set; }
        public EventProductDropStock(Guid aggregateId, int qtyRemaining) : base(aggregateId)
        {
            QtyRemaining = qtyRemaining;
        }
    }
}
