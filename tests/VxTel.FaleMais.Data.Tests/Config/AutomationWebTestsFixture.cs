using Bogus;
using Xunit;

namespace VxTel.TalkMore.Data.Tests.Config
{
	[CollectionDefinition(nameof(AutomacaoWebFixtureCollection))]
	public class AutomacaoWebFixtureCollection : ICollectionFixture<AutomationWebTestsFixture> { }

	public class AutomationWebTestsFixture
	{
		public SeleniumHelper BrowserHelper;
		public readonly ConfigurationHelper Configuration;
		
		public AutomationWebTestsFixture()
		{
			Configuration = new ConfigurationHelper();
			BrowserHelper = new SeleniumHelper(Browser.Chrome, Configuration, false);
		}

	}
}
