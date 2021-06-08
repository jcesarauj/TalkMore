namespace VxTel.TalkMore.Ui.Models
{
	public class CalculateCallRequest
	{
		public int Origin { get; set; }
		public int Destiny { get; set; }
		public int CallTimeInMinutes { get; set; }
		public int PlanId { get; set; }
	}
}