using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.TalkMore.Domain.Models;

namespace VxTel.TalkMore.Domain.Contracts.Queries
{
	public interface IPlanQueries
	{
		Task<IList<Plan>> Get();

		Task<Plan> GetById(int id);
	}
}