using FluentAssertions;
using TechTalk.SpecFlow;
using VxTel.TalkMore.Data.Tests.Config;
using VxTel.TalkMore.Data.Tests.Pages;
using VxTel.TalkMore.Domain.Models;

namespace VxTel.TalkMore.Data.Tests
{
	[Binding]
	public class CalcularValorDaLigacaoSteps
	{
		private readonly AutomationWebTestsFixture _testFixture;
		private readonly CalculateCallScreen _calculateCallScreen;

		public CalcularValorDaLigacaoSteps(AutomationWebTestsFixture testFixture)
		{
			_testFixture = testFixture;
			_calculateCallScreen = new CalculateCallScreen(testFixture.BrowserHelper);
		}

		[Given(@"que o utilizador informou os dados no formulario")]
		public void DadoQueOUtilizadorInformouOsDadosNoFormulario()
		{
			//Arrange
			_calculateCallScreen.Go();
			_calculateCallScreen.Origin = 11;
			_calculateCallScreen.Destiny = 16;
			_calculateCallScreen.CallTimeInMinutes = 120;
			_calculateCallScreen.PlanId = 2;

			//Act
			_calculateCallScreen.FillFields();

			//Assert
			_calculateCallScreen.ValidatevalidateIfItsInUrl().Should().BeTrue();
		}

		[When(@"clicar em calcular")]
		public void QuandoClicarEmCalcular()
		{
			//Arrange

			//Act
			_calculateCallScreen.ClickInTheButtonCalculate();

			//Assert
		}

		[Then(@"O valor dos planos FaleMais deve ser calculado e exibido para o usuário")]
		public void EntaoOValorDosPlanosFaleMaisDeveSerCalculadoEExibidoParaOUsuario()
		{
			//Arrange
			var plan = new Plan(2, "FaleMais 60", 60, 10);
			var callFee = new CallFee(2, 11, 16, 1.90);
			var valueScreenWithPlan = _calculateCallScreen.CalculedWithTalkMore();
			var valueScreenWithOutPlan = _calculateCallScreen.CalculedWithOutTalkMore();

			//Act
			plan.CalculateExceededMinutes(_calculateCallScreen.CallTimeInMinutes);
			plan.CalculateValuePlanWithExceededMinutes(callFee.CostPerMinute);
			callFee.CalculateFeePerMinutes(_calculateCallScreen.CallTimeInMinutes);

			//Assert
			valueScreenWithPlan.Should().Be(plan.ValuePlanWithExceededMinutes);
			valueScreenWithOutPlan.Should().Be(callFee.TotalFee);
		}
	}
}