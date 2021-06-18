using VxTel.TalkMore.Core.Messages;

namespace VxTel.TalkMore.Application.CalculedValueCall
{
	public class CalculateCallValueCommand : Command
	{
		public CalculateCallValueCommand(int origin, int destiny, int callTimeInMinutes, int planId)
		{
			Origin = origin;
			Destiny = destiny;
			CallTimeInMinutes = callTimeInMinutes;
			PlanId = planId;
		}

		public int Origin { get; set; }
		public int Destiny { get; set; }
		public int CallTimeInMinutes { get; set; }
		public int PlanId { get; set; }
	}
}