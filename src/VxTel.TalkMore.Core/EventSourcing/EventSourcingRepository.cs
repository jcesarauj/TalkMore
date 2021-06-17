using EventStore.ClientAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VxTel.TalkMore.Core.Messages;

namespace VxTel.TalkMore.Core.EventSourcing
{
	public class EventSourcingRepository : IEventSourcingRepository
    {
        private readonly IEventStoreService _eventStoreService;

        public EventSourcingRepository(IEventStoreService eventStoreService)
        {
            _eventStoreService = eventStoreService;
        }

        public async Task SaveEvent<TEvent>(TEvent @event) where TEvent : Event
        {
            await _eventStoreService.GetConnection().AppendToStreamAsync(
                @event.AgregatedId.ToString(),
                ExpectedVersion.Any,
                FormatEvent(@event));
        }

        public async Task<IEnumerable<StoredEvent>> GetEvents(Guid aggregateId)
        {
            var events = await _eventStoreService.GetConnection()
                .ReadStreamEventsForwardAsync(aggregateId.ToString(), 0, 500, false);

            var eventList = new List<StoredEvent>();

            foreach (var resolvedEvent in events.Events)
            {
                var dataEncoded = Encoding.UTF8.GetString(resolvedEvent.Event.Data);
                var jsonData = JsonConvert.DeserializeObject<BaseEvent>(dataEncoded);

                var evento = new StoredEvent(
                    resolvedEvent.Event.EventId,
                    resolvedEvent.Event.EventType,
                    jsonData.Timestamp,
                    dataEncoded);

                eventList.Add(evento);
            }

            return eventList.OrderBy(e => e.RegisterDate);
        }

        private static IEnumerable<EventData> FormatEvent<TEvent>(TEvent @event) where TEvent : Event
        {
            yield return new EventData(
                Guid.NewGuid(),
                @event.MessageType,
                true,
                Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event)),
                null);
        }
    }

    internal class BaseEvent
    {
        public DateTime Timestamp { get; set; }
    }
}