using Microsoft.Extensions.Configuration;
using System.IO;

namespace VxTel.TalkMore.Data.Tests.Config
{
	public class ConfigurationHelper
	{
		private readonly IConfiguration _config;

		public ConfigurationHelper()
		{
			_config = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.Build();
		}

		public string CalculatePlanUrl => _config.GetSection("CalculatePlanUrl").Value;
		public string DomainUrl => _config.GetSection("DomainUrl").Value;
		public string WebDrivers => $"{_config.GetSection("WebDrivers").Value}";		
		public string FolderPicture => $"{FolderPath}{_config.GetSection("FolderPicture").Value}";
		public string FolderPath => Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
	}
}

