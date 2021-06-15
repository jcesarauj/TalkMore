using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VxTel.TalkMore.Application.CalculateCallValue;
using VxTel.TalkMore.Core.Contracts.Mediator;
using VxTel.TalkMore.Core.DomainObjects;
using VxTel.TalkMore.Core.DomainObjects.Dtos;
using VxTel.TalkMore.Domain.Contracts.Repository;

namespace VxTel.TalkMore.Application.CalculedValueCall
{
	public class CalculateCallValueHandler :
		IRequestHandler<CalculateCallValueCommand, Dto>
	{
		private readonly ICallFeeRepository _callFeeRepository;
		private readonly IPlanRepository _planRepository;
		private readonly IMediatorHandler _mediatorHandler;

		public CalculateCallValueHandler(ICallFeeRepository callFeeRepository, IPlanRepository planRepository, IMediatorHandler mediatorHandler)
		{
			_callFeeRepository = callFeeRepository;
			_planRepository = planRepository;
			_mediatorHandler = mediatorHandler;
		}

		public async Task<Dto> Handle(CalculateCallValueCommand request, CancellationToken cancellationToken)
		{
			var callFee = await _callFeeRepository.GetByOriginAndDestiny(request.Origin, request.Destiny);
			AssertionConcern.ValidateIfNull(callFee, "Taxa não encontrada para a origem e destino informada");

			var plan = await _planRepository.GetById(request.PlanId);
			AssertionConcern.ValidateIfNull(plan, "Plano não encontrado para a origem e destino");

			var calculedValueCallDto = new CalculateCallValueBuilder()
				.WithPlan(plan)
				.WithCallFee(callFee)
				.WithOrigin(request.Origin)
				.WithDestiny(request.Destiny)
				.WithCallTimeInMinutes(request.CallTimeInMinutes)
				.CalculateExceededMinutes()
				.CalculateWithTalkMore()
				.CalculateWithOutTalkMore()
				.Build();

			await _mediatorHandler.PublishEvent(calculedValueCallDto.ToCalculedValueCallEvent());

			return calculedValueCallDto;
		}
	}
}