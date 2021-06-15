using VxTel.TalkMore.Application.CalculedValueCall;

namespace VxTel.TalkMore.Application.CalculateCallValue
{
	public static class CalculedValueCall
	{
		public static CalculedValueCallEvent ToCalculedValueCallEvent(this CalculedValueCallDto calculedValueCallDto)
		{
			return new CalculedValueCallEvent()
			{
				Destiny = calculedValueCallDto.Destiny,
				Origin = calculedValueCallDto.Origin,
				Plan = calculedValueCallDto.Plan,
				WithOutTalkMore = calculedValueCallDto.WithOutTalkMore,
				WithTalkMore = calculedValueCallDto.WithOutTalkMore
			};
		}
	}
}
