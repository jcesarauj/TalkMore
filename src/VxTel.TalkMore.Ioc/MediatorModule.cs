using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using VxTel.TalkMore.Application.CalculedValueCall;
using VxTel.TalkMore.Core.Comunication.Mediator;
using VxTel.TalkMore.Core.Contracts.Mediator;
using VxTel.TalkMore.Core.DomainObjects.Dtos;

namespace VxTel.TalkMore.Ioc
{
	public static class MediatorModule
	{
		public static void AddMediatr(this IServiceCollection services)
		{
			services.AddScoped<IMediatorHandler, MediatorHandler>();
			services.AddScoped<IRequestHandler<CalculateCallValueCommand, Dto>, CalculateCallValueHandler>();
			services.AddTransient<IValidator<CalculateCallValueCommand>, CalculateCallValueValidation>();
		}
	}
}