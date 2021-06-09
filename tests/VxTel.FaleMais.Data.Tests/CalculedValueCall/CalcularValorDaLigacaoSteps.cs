using FluentAssertions;
using TechTalk.SpecFlow;
using VxTel.TalkMore.Data.Tests.Config;
using VxTel.TalkMore.Data.Tests.Pages;
using VxTel.TalkMore.Domain.Contracts.Repository;
using VxTel.TalkMore.Domain.Models;

namespace VxTel.TalkMore.Data.Tests
{
	[Binding]
	public class CalcularValorDaLigacaoSteps
	{
		private readonly AutomationWebTestsFixture _testFixture;
		private readonly CalculateCallScreen _calculateCallScreen;
		private readonly IPlanRepository _planRepository;
		private readonly ICallFeeRepository _callFeeRepository;

		public CalcularValorDaLigacaoSteps(AutomationWebTestsFixture testFixture, IPlanRepository planRepository, ICallFeeRepository callFeeRepository)
		{
			_testFixture = testFixture;
			_calculateCallScreen = new CalculateCallScreen(testFixture.BrowserHelper);
			_planRepository = planRepository;
			_callFeeRepository = callFeeRepository;
		}

		[Given(@"que o utilizador informou os dados no formulario")]
		public void DadoQueOUtilizadorInformouOsDadosNoFormulario()
		{
			//Arrange
			_calculateCallScreen.Go();
			_calculateCallScreen.Origin = "11";
			_calculateCallScreen.Origin = "16";
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
			var plan = _planRepository.GetById(_calculateCallScreen.PlanId).Result;
			var callFee = _callFeeRepository.GetByOriginAndDestiny(_calculateCallScreen.Origin, _calculateCallScreen.Destiny).Result;
			var valueScreenWithPlan = 0.0;
			var valueScreenWithOutPlan = 0.0;

			//Act
			plan.CalculateExceededMinutes(_calculateCallScreen.CallTimeInMinutes);
			plan.CalculateValuePlanWithExceededMinutes(callFee.CostPerMinute);
			///TODO: pegar o valor da tela

			//Assert
			valueScreenWithPlan.Should().Be(plan.ValuePlanWithExceededMinutes);
			valueScreenWithOutPlan.Should().Be(callFee.TotalFee);
		}
	}
}