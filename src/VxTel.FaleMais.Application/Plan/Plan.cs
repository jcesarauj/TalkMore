using System.Collections.Generic;
using System.Linq;
using domain = VxTel.TalkMore.Domain.Models;

namespace VxTel.TalkMore.Application.Plan
{
	public static class Plan
	{
		public static PlanDto PlanToPlanDto(this domain.Plan plan)
		{
			return new PlanDto()
			{
				Id = plan.Id,
				Name = plan.Name
			};
		}

		public static IList<PlanDto> PlanToPlanDtoList(this IList<domain.Plan> plan)
		{
			IList<PlanDto> newList = new List<PlanDto>();
			plan.ToList().ForEach(item => newList.Add(item.PlanToPlanDto()));
			return newList;
		}
	}
}