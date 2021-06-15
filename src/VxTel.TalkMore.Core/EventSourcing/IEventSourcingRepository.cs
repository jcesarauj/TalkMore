using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.TalkMore.Core.Messages;

namespace VxTel.TalkMore.Core.EventSourcing
{
	public interface IEventSourcingRepository
    {
        Task SaveEvent<TEvent>(TEvent @event) where TEvent : Event;
        Task<IEnumerable<StoredEvent>> GetEvents(Guid aggregateId);
    }
}