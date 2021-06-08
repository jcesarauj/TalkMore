using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VxTel.TalkMore.Domain.Contracts.Repository;
using VxTel.TalkMore.Domain.Models;

namespace VxTel.TalkMore.Data.Repository
{
	public class CallFeeRepository : ICallFeeRepository
	{
		private readonly TalkMoreContext _context;

		public CallFeeRepository(TalkMoreContext context)
		{
			_context = context;
		}

		public async Task<CallFee> GetByOriginAndDestiny(int origin, int destiny) => await _context.CallFee.FirstOrDefaultAsync(t => t.Origin == origin && t.Destiny == destiny);
	}
}