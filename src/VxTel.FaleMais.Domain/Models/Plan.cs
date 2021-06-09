namespace VxTel.TalkMore.Domain.Models
{
	public class Plan
	{
		public int Id { get; private set; }
		public string Name { get; private set; }
		public int FreeTimeInMinutes { get; private set; }
		public int OverTimeRatePercent { get; private set; }
		public int ExceededMinutes { get; private set; }
		public double ValuePlanWithExceededMinutes { get; private set; }

		public Plan(int id, string name, int freeTimeInMinutes, int overTimeRatePercent)
		{
			Id = id;
			Name = name;
			FreeTimeInMinutes = freeTimeInMinutes;
			OverTimeRatePercent = overTimeRatePercent;
		}

		public void CalculateExceededMinutes(int callTimeInMinutes)
		{
			ExceededMinutes = callTimeInMinutes - FreeTimeInMinutes;
			if (ExceededMinutes < 0) ExceededMinutes = 0;
		}

		public void CalculateValuePlanWithExceededMinutes(double costPerMinute)
		{
			ValuePlanWithExceededMinutes = ExceededMinutes * costPerMinute;
			ValuePlanWithExceededMinutes += ValuePlanWithExceededMinutes / OverTimeRatePercent;
		}

		public bool IsExceededMinutes() => ExceededMinutes > 0;
	}
}