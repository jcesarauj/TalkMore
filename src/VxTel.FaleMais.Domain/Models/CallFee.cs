namespace VxTel.TalkMore.Domain.Models
{
	public class CallFee
	{
		public int Id { get; private set; }
		public int Origin { get; private set; }
		public int Destiny { get; private set; }
		public double CostPerMinute { get; private set; }
		public double TotalFee { get; private set; }

		public CallFee(int id, int origin, int destiny, double costPerMinute)
		{
			Id = id;
			Origin = origin;
			Destiny = destiny;
			CostPerMinute = costPerMinute;
		}

		public void CalculateFeePerMinutes(int callTimeInMinutes) => TotalFee = callTimeInMinutes * CostPerMinute;
	}
}