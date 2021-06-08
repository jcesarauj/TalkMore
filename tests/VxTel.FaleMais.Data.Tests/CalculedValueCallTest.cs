using FluentAssertions;
using VxTel.TalkMore.Domain.Models;
using Xunit;

namespace VxTel.TalkMore.Data.Tests
{
	public class CalculedValueCallTest
	{
		[Theory(DisplayName = "Deve Calcular o Valor do Plano com o fale mais")]
		[InlineData(1, "FaleMais 30", 30, 10, 20, 1.90, 0)]
		[InlineData(2, "FaleMais 60", 60, 10, 80, 1.70, 37.40)]
		[InlineData(3, "FaleMais 120", 120, 10, 200, 1.90, 167.20)]
		[InlineData(4, "FaleMais 30", 30, 10, 100, 0, 0)]
		public void CalculedValueCall_NewPlanQuery_ShouldCalculatePlanWithTalkMore(int planId, string planName, int freeTimeInMinutes, int overTimeRatePercent, int callTimeInMinutes,
			double costPerMinute, double expected)
		{
			//Arrange
			var plan = new Plan(planId, planName, freeTimeInMinutes, overTimeRatePercent);

			//Act
			plan.CalculateExceededMinutes(callTimeInMinutes);
			plan.CalculateValuePlanWithExceededMinutes(costPerMinute);

			//Assert
			plan.ValuePlanWithExceededMinutes.Should().Be(expected);
		}

		[Theory(DisplayName = "Deve Calcular o Valor das taxas sem o fale mais")]
		[InlineData(1, 11, 16, 1.90, 20, 38)]
		[InlineData(2, 11, 17, 1.70, 80, 136)]
		[InlineData(3, 18, 11, 1.90, 200, 380)]
		[InlineData(4, 18, 17, 0, 100, 0)]
		public void CalculedValueCall_NewPlanQuery_ShouldCalculatePlanWithOutTalkMore(int callFeeId, int origin, int destiny, double costPerMinute, int callTimeInMinutes, double expected)
		{
			//Arrange
			var callFee = new CallFee(callFeeId, origin, destiny, costPerMinute);

			//Act
			callFee.CalculateFeePerMinutes(callTimeInMinutes);

			//Assert
			callFee.TotalFee.Should().Be(expected);
		}
	}
}