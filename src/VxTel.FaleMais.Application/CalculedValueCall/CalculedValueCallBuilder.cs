using VxTel.TalkMore.Domain.Models;

using domain = VxTel.TalkMore.Domain.Models;

namespace VxTel.TalkMore.Application.CalculedValueCall
{
	public class CalculedValueCallBuilder
	{
		private CallFee _callFee;
		private domain.Plan _plan;
		private readonly CalculedValueCallDto _calculedValueCallDto = new CalculedValueCallDto();
		private int _callTimeInMinutes;
		private int _origin;
		private int _destiny;

		public CalculedValueCallBuilder WithCallFee(CallFee callFee)
		{
			_callFee = callFee;
			return this;
		}

		public CalculedValueCallBuilder WithPlan(domain.Plan plan)
		{
			_plan = plan;
			return this;
		}

		public CalculedValueCallBuilder WithOrigin(int origin)
		{
			_origin = origin;
			return this;
		}

		public CalculedValueCallBuilder WithDestiny(int destiny)
		{
			_destiny = destiny;
			return this;
		}

		public CalculedValueCallBuilder WithCallTimeInMinutes(int callTimeInMinutes)
		{
			_callTimeInMinutes = callTimeInMinutes;
			return this;
		}

		public CalculedValueCallBuilder CalculateExceededMinutes()
		{
			_plan.CalculateExceededMinutes(_callTimeInMinutes);
			return this;
		}

		public CalculedValueCallBuilder CalculateWithTalkMore()
		{
			if (_plan.IsExceededMinutes())
			{
				_plan.CalculateValuePlanWithExceededMinutes(_callFee.CostPerMinute);
				_calculedValueCallDto.WithTalkMore = _plan.ValuePlanWithExceededMinutes;
			}
			return this;
		}

		public CalculedValueCallBuilder CalculateWithOutTalkMore()
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