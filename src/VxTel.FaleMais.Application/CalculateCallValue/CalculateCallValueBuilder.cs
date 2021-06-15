using VxTel.TalkMore.Domain.Models;

using domain = VxTel.TalkMore.Domain.Models;

namespace VxTel.TalkMore.Application.CalculedValueCall
{
	public class CalculateCallValueBuilder
	{
		private CallFee _callFee;
		private domain.Plan _plan;
		private readonly CalculedValueCallDto _calculedValueCallDto = new CalculedValueCallDto();
		private int _callTimeInMinutes;
		private int _origin;
		private int _destiny;

		public CalculateCallValueBuilder WithCallFee(CallFee callFee)
		{
			_callFee = callFee;
			return this;
		}

		public CalculateCallValueBuilder WithPlan(domain.Plan plan)
		{
			_plan = plan;
			return this;
		}

		public CalculateCallValueBuilder WithOrigin(int origin)
		{
			_origin = origin;
			return this;
		}

		public CalculateCallValueBuilder WithDestiny(int destiny)
		{
			_destiny = destiny;
			return this;
		}

		public CalculateCallValueBuilder WithCallTimeInMinutes(int callTimeInMinutes)
		{
			_callTimeInMinutes = callTimeInMinutes;
			return this;
		}

		public CalculateCallValueBuilder CalculateExceededMinutes()
		{
			_plan.CalculateExceededMinutes(_callTimeInMinutes);
			return this;
		}

		public CalculateCallValueBuilder CalculateWithTalkMore()
		{
			if (_plan.IsExceededMinutes())
			{
				_plan.CalculateValuePlanWithExceededMinutes(_callFee.CostPerMinute);
				_calculedValueCallDto.WithTalkMore = _plan.ValuePlanWithExceededMinutes;
			}
			return this;
		}

		public CalculateCallValueBuilder CalculateWithOutTalkMore()
		{
			_callFee.CalculateFeePerMinutes(_callTimeInMinutes);
			_calculedValueCallDto.WithOutTalkMore = _callFee.TotalFee;
			return this;
		}

		public CalculedValueCallDto Build()
		{
			_calculedValueCallDto.Origin = _origin;
			_calculedValueCallDto.Destiny = _destiny;
			_calculedValueCallDto.Plan = _plan.Name;
			_calculedValueCallDto.TimeInMinutes = _callTimeInMinutes;

			return _calculedValueCallDto;
		}
	}
}