using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VxTel.TalkMore.Application.CalculedValueCall;
using VxTel.TalkMore.Core.Contracts.Mediator;
using VxTel.TalkMore.Core.Extensions;

namespace VxTel.TalkMore.Api.Controllers.V1
{
	[Route("api/v1/calculatevaluecall")]
	public class CalculateValueCallController : Controller
	{
		private readonly IMediatorHandler _mediatorHandler;

		public CalculateValueCallController(IMediatorHandler mediatorHandler)
		{
			_mediatorHandler = mediatorHandler;
		}

		[HttpPost]
		public async Task<IActionResult> CalculateValueCall([FromBody] CalculateValueCallCommand calculateValueCallCommand)
		{
			var result = await _mediatorHandler.SendCommand(calculateValueCallCommand);
			return result.ToResponse();
		}
	}
}