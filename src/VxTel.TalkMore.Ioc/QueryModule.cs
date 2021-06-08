using Microsoft.Extensions.DependencyInjection;
using VxTel.TalkMore.Domain.Contracts.Queries;
using VxTel.TalkMore.Domain.Queries;

namespace VxTel.TalkMore.Ioc
{
	public static class QueryModule
	{
		public static void AddQueries(this IServiceCollection services)
		{
			services.AddScoped<IPlanQueries, PlanQueries>();
		}
	}
}