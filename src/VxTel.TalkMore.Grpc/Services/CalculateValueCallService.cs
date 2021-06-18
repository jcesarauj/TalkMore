using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using VxTel.TalkMore.Application.CalculedValueCall;
using VxTel.TalkMore.Core.Contracts.Mediator;
using VxTel.TalkMore.Core.Extensions;
using VxTel.TalkMore.Grpc.Protos;

namespace VxTel.TalkMore.Grpc
{
	public class CalculateValueCallService : CalculateValueCall.CalculateValueCallBase
	{
		private readonly ILogger<CalculateValueCallService> _logger;
		private readonly IMediatorHandler _mediatorHandler;

		public CalculateValueCallService(IMediatorHandler mediatorHandler, ILogger<CalculateValueCallService> logger)
		{
			_logger = logger;
			_mediatorHandler = mediatorHandler;
		}
		public async override Task<CalculateValueCallReply> CalculateValueCall(CalculateValueCallRequest request, ServerCallContext context)
		{
			var result = await _mediatorHandler.SendCommand(new CalculateCallValueCommand(request.Destiny, request.Origin, request.CallTimeInMinutes, request.PlanId));

			return await Task.FromResult(new CalculateValueCallReply()
			{
				Success = true,
				Data = result.ToJson()
			});
		}
	}
}