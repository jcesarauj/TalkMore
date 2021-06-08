using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.TalkMore.Domain.Contracts.Repository;
using VxTel.TalkMore.Domain.Models;

namespace VxTel.TalkMore.Data.Repository
{
	public class PlanRepository : IPlanRepository
	{
		private readonly TalkMoreContext _context;

		public PlanRepository(TalkMoreContext context)
		{
			_context = context;
		}

		public async Task<IList<Plan>> Get() => await _context.Plan.ToListAsync();

		public async Task<Plan> GetById(int id) => await _context.Plan.FirstOrDefaultAsync(x => x.Id == id);
	}
}