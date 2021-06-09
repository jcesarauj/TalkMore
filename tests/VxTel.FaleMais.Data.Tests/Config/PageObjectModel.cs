namespace VxTel.TalkMore.Data.Tests.Config
{
	public abstract class PageObjectModel
	{
		protected readonly SeleniumHelper Helper;

		protected PageObjectModel(SeleniumHelper helper) { Helper = helper; }

		public string ObterUrl() => Helper.GetUrl();

		public void NavegarParaUrl(string url) => Helper.GoToUrl(url);
	}
}