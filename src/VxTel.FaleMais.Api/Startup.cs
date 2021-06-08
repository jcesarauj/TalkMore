using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using VxTel.TalkMore.Api.Middlewares;
using VxTel.TalkMore.Core.DomainObjects;
using VxTel.TalkMore.Data;
using VxTel.TalkMore.Ioc;

namespace VxTel.TalkMore.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.Inject();

			services.AddMediatR(Assembly.GetExecutingAssembly());
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavor<,>));
			services.AddValidatorsFromAssembly(typeof(Startup).Assembly);

			services.AddDbContext<TalkMoreContext>(opt => opt.UseInMemoryDatabase("TalkMore"));
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
				{
					Title = "TalkMore.Api",
					Version = "v1"
				});
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMiddleware(typeof(ErrorHandlingMiddleware));

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			app.UseSwagger();
			app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "TalkMore.Api"));
		}
	}
}