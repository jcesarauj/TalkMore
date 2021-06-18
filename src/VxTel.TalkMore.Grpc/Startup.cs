using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using VxTel.TalkMore.Core.DomainObjects;
using VxTel.TalkMore.Data;
using VxTel.TalkMore.Ioc;

namespace VxTel.TalkMore.Grpc
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddGrpc();
			services.AddGrpcHttpApi();
			services.Inject();
			services.AddMediatR(Assembly.GetExecutingAssembly());
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavor<,>));
			services.AddValidatorsFromAssembly(typeof(Startup).Assembly);
			services.AddDbContext<TalkMoreContext>(opt => opt.UseInMemoryDatabase("TalkMore"));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGrpcService<CalculateValueCallService>();

				endpoints.MapGet("/", async context =>
				{
					await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
				});
			});
		}
	}
}
