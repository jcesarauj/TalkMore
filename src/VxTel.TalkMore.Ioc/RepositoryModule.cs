using Microsoft.Extensions.DependencyInjection;
using VxTel.TalkMore.Data.Repository;
using VxTel.TalkMore.Domain.Contracts.Repository;

namespace VxTel.TalkMore.Ioc
{
	public static class RepositoryModule
	{
		public static void AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<IPlanRepository, PlanRepository>();
			services.AddScoped<ICallFeeRepository, CallFeeRepository>();
		}
	}
}