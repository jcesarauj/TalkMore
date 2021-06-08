using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VxTel.TalkMore.Core.Contracts.Mediator;
using VxTel.TalkMore.Core.DomainObjects;
using VxTel.TalkMore.Core.DomainObjects.Dtos;
using VxTel.TalkMore.Domain.Contracts.Repository;

namespace VxTel.TalkMore.Application.CalculedValueCall
{
	public class CalculedValueCallHandler :
		IRequestHandler<CalculateValueCallCommand, Dto>
	{
		private readonly ICallFeeRepository _callFeeRepository;
		private readonly IPlanRepository _planRepository;

		public CalculedValueCallHandler(ICallFeeRepository callFeeRepository, IPlanRepository planRepository)
		{
			_callFeeRepository = callFeeRepository;
			_planRepository = planRepository;
		}

		public async Task<Dto> Handle(CalculateValueCallCommand request, CancellationToken cancellationToken)
		{
			var callFee = await _callFeeRepository.GetByOriginAndDestiny(request.Origin, request.Destiny);
			AssertionConcern.ValidateIfNull(callFee, "Taxa não encontrada para a origem e destino informada");

			var plan = await _planRepository.GetById(request.PlanId);
			AssertionConcern.ValidateIfNull(plan, "Plano não encontrado para a origem e destino");

			var calculedValueCallDto = new CalculedValueCallBuilder()
				.WithPlan(plan)
				.WithCallFee(callFee)
				.WithOrigin(request.Origin)
				.WithDestiny(request.Destiny)
				.WithCallTimeInMinutes(request.CallTimeInMinutes)
				.CalculateExceededMinutes()
				.CalculateWithTalkMore()
				.CalculateWithOutTalkMore()
				.Build();

			return calculedValueCallDto;
		}
	}
}