using VxTel.TalkMore.Data.Tests.Config;

namespace VxTel.TalkMore.Data.Tests.Pages
{
	public class CalculateCallScreen : PageObjectModel
	{
		public CalculateCallScreen(SeleniumHelper helper) : base(helper) { }
		public void Go()
		{
			Helper.GoToUrl(Helper.Configuration.DomainUrl);
			Helper.ClickLinkByText("Calcular Valor Ligação");
		}
		public void FillFields()
		{
			Helper.FillDropDownById("Origin", Origin.ToString());
			Helper.FillDropDownById("Destiny", Destiny.ToString());
			Helper.FillTextBoxById("CallTimeInMinutes", CallTimeInMinutes.ToString());
			Helper.FillDropDownById("PlanId", PlanId.ToString());
		}
		public bool ValidatevalidateIfItsInUrl() => Helper.ValidarConteudoUrl(Helper.Configuration.CalculatePlanUrl);

		public void ClickInTheButtonCalculate() => Helper.ClickButomById("Calculate");

		public int Origin { get; set; }
		public int Destiny { get; set; }
		public int CallTimeInMinutes { get; set; }
		public int PlanId { get; set; }
	}
}
