using FluentValidation;

namespace VxTel.TalkMore.Application.CalculedValueCall
{
	public class CalculedValueCallValidation : AbstractValidator<CalculateValueCallCommand>
	{
		public CalculedValueCallValidation()
		{
			RuleFor(c => c.Origin)
					.NotEmpty()
					.WithMessage("Informe a origem");

			RuleFor(c => c.Destiny)
				.NotEmpty()
				.WithMessage("Informe o destino");

			RuleFor(c => c.PlanId)
				.NotEmpty()
				.WithMessage("Informe o plano");

			RuleFor(c => c.CallTimeInMinutes)
				.NotEmpty()
				.WithMessage("Informe o tempo em minutos");
		}
	}
}