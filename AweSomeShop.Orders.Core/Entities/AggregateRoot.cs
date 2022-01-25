using System;
using System.Collections.Generic;

namespace AweSomeShop.Orders.Core.Entities
{
    public class AggregateRoot : Entity
    {
        private List<IDomainEvent> _events = new List<IDomainEvent>();
        
        private IEnumerable<IDomainEvent> Events => _events;

        protected void AddEvent(IDomainEvent @event){
            if(_events == null)
                _events = new List<IDomainEvent>();
            _events.Add(@event);
        }
    }
}