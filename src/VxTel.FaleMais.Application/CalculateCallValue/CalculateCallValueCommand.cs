using VxTel.TalkMore.Core.Messages;

namespace VxTel.TalkMore.Application.CalculedValueCall
{
	public class CalculateCallValueCommand : Command
	{
		public int Origin { get; set; }
		public int Destiny { get; set; }
		public int CallTimeInMinutes { get; set; }
		public int PlanId { get; set; }
	}
}