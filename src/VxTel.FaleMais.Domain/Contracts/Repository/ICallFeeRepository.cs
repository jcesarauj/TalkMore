using System.Threading.Tasks;
using VxTel.TalkMore.Domain.Models;

namespace VxTel.TalkMore.Domain.Contracts.Repository
{
	public interface ICallFeeRepository
	{
		Task<CallFee> GetByOriginAndDestiny(int origin, int destiny);
	}
}