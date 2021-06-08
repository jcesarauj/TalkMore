using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Text;
using VxTel.TalkMore.Ui.Models;

namespace VxTel.TalkMore.Ui.Helper
{
	public static class CalculateCallHelper
	{
		private const string calculatevaluecallUri = "https://localhost:44317/api/v1/calculatevaluecall";
		private const string plansUri = "https://localhost:44317/api/v1/plan";

		public static CalculateCallResponse SearchPlan(CalculateCallRequest calculateCallResquest)
		{
			WebRequest request = WebRequest.Create(calculatevaluecallUri);
			request.Method = "POST";
			byte[] byteArray = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(calculateCallResquest));
			request.ContentType = "application/json; charset=utf-8";
			request.ContentLength = byteArray.Length;
			Stream dataStream = request.GetRequestStream();
			dataStream.Write(byteArray, 0, byteArray.Length);
			dataStream.Close();

			WebResponse response = request.GetResponse();

			using (dataStream = response.GetResponseStream())
			{
				StreamReader reader = new StreamReader(dataStream);
				var result = JsonConvert.DeserializeObject<dynamic>(reader.ReadToEnd());
				if ((bool)result.success) return JsonConvert.DeserializeObject<CalculateCallResponse>(result.data.ToString(), new JsonSerializerSettings { FloatParseHandling = FloatParseHandling.Double });
			}

			response.Close();

			return null;
		}

		public static dynamic GetPlans()
		{
			WebRequest request = WebRequest.Create(plansUri);
			WebResponse response = request.GetResponse();

			using (Stream dataStream = response.GetResponseStream())
			{
				StreamReader reader = new StreamReader(dataStream);
				string json = reader.ReadToEnd();
				return JsonConvert.DeserializeObject<dynamic>(json).data;
			}
		}
	}
}
