using Newtonsoft.Json;

namespace VxTel.TalkMore.Core.Extensions
{
	public static class JsonExtension
	{
		public static string ToJson(this object result)
		{
			return JsonConvert.SerializeObject(result);
		}
	}
}