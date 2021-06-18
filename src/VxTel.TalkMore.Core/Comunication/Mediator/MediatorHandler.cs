using MediatR;
using System.Threading.Tasks;
using VxTel.TalkMore.Core.Contracts.Mediator;
using VxTel.TalkMore.Core.DomainObjects.Dtos;
using VxTel.TalkMore.Core.EventSourcing;
using VxTel.TalkMore.Core.Messages;
using VxTel.TalkMore.Core.Messages.CommonMessages.Notifications;

namespace VxTel.TalkMore.Core.Comunication.Mediator
{
	public class MediatorHandler : IMediatorHandler
	{
		private readonly IMediator _mediator;
		//private readonly IEventSourcingRepository _eventSourcingRepository;

		public MediatorHandler(IMediator mediator, IEventSourcingRepository eventSourcingRepository)
		{
			_mediator = mediator;
			//_eventSourcingRepository = eventSourcingRepository;
		}

		public async Task PublishEvent<T>(T @event) where T : Event
		{
			await _mediator.Publish(@event);
			//await _eventSourcingRepository.SaveEvent(@event);
		}

		public async Task PublishNotification<T>(T notification) where T : DomainNotification
		{
			await _mediator.Publish(notification);
		}

		public async Task<Dto> SendCommand<T>(T command) where T : Command
		{
			var result = await _mediator.Send(command);
			return result;
		}
	}
}