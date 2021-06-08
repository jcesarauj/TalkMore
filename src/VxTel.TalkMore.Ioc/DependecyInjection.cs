using Microsoft.Extensions.DependencyInjection;

namespace VxTel.TalkMore.Ioc
{
	public static class DependecyInjection
	{
		public static void Inject(this IServiceCollection services)
		{
			services.AddRepositories();
			services.AddMediatr();
			services.AddQueries();
		}
	}
}