using System.Threading.Tasks;
using VxTel.TalkMore.Core.DomainObjects.Dtos;
using VxTel.TalkMore.Core.Messages;
using VxTel.TalkMore.Core.Messages.CommonMessages.Notifications;

namespace VxTel.TalkMore.Core.Contracts.Mediator
{
	public interface IMediatorHandler
	{
		Task PublishEvent<T>(T @event) where T : Event;

		Task<Dto> SendCommand<T>(T command) where T : Command;

		Task PublishNotification<T>(T notification) where T : DomainNotification;
	}
}