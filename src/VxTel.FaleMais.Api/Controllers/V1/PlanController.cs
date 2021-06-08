using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VxTel.TalkMore.Application.Plan;
using VxTel.TalkMore.Core.Extensions;
using VxTel.TalkMore.Domain.Contracts.Queries;

namespace VxTel.TalkMore.Api.Controllers.V1
{
	[Route("api/v1/plan")]
	[ApiController]
	public class PlanController : Controller
	{
		private readonly IPlanQueries _planQueries;

		public PlanController(IPlanQueries planQueries)
		{
			_planQueries = planQueries;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return (await _planQueries.Get()).PlanToPlanDtoList().ToResponse();
		}
	}
}