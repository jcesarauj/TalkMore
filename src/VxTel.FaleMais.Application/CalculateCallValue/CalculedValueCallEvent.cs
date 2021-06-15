using VxTel.TalkMore.Core.Messages;

namespace VxTel.TalkMore.Application.CalculedValueCall
{
	public class CalculedValueCallEvent : Event
	{
		public int Origin { get; set; }
		public int Destiny { get; set; }
		public int TimeInMinutes { get; set; }
		public string Plan { get; set; }
		public double WithTalkMore { get; set; }
		public double WithOutTalkMore { get; set; }
	}
}