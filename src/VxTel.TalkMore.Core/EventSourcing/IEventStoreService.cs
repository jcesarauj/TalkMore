using EventStore.ClientAPI;

namespace VxTel.TalkMore.Core.EventSourcing
{
    public interface IEventStoreService
    {
        IEventStoreConnection GetConnection();
    }
}