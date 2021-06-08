using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.TalkMore.Domain.Contracts.Queries;
using VxTel.TalkMore.Domain.Contracts.Repository;
using VxTel.TalkMore.Domain.Models;

namespace VxTel.TalkMore.Domain.Queries
{
	public class PlanQueries : IPlanQueries
	{
		private readonly IPlanRepository _planRepository;

		public PlanQueries(IPlanRepository planRepository)
		{
			_planRepository = planRepository;
		}

		public Task<IList<Plan>> Get()
		{
			return _planRepository.Get();
		}

		public Task<Plan> GetById(int id)
		{
			return _planRepository.GetById(id);
		}
	}
}