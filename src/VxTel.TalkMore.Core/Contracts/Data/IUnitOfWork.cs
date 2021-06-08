using System.Threading.Tasks;

namespace VxTel.TalkMore.Core.Contracts.Data
{
	public interface IUnitOfWork
	{
		Task<bool> Commit();

		Task<bool> RollBack();
	}
}