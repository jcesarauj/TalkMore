using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VxTel.TalkMore.Application.CalculedValueCall;

namespace NerdStore.Sales.Domain.Handlers
{
	public class CalculateCallValueEventHandler :
		INotificationHandler<CalculedValueCallEvent>
	{
		public CalculateCallValueEventHandler() { }

		public Task Handle(CalculedValueCallEvent calculedValueCallEvent, CancellationToken cancellationToken)
		{
			return Task.CompletedTask;
		}
	}
}
