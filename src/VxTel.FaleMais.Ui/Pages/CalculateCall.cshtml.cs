using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using VxTel.TalkMore.Ui.Helper;
using VxTel.TalkMore.Ui.Models;

namespace VxTel.TalkMore.Ui.Pages
{
	public class CalculateCall : PageModel
	{
		private readonly ILogger<CalculateCall> _logger;
		public List<SelectListItem> PlanOptions { get; set; } = new List<SelectListItem>();

		[BindProperty]
		public CalculateCallRequest CalculateCallRequest { get; set; } = new CalculateCallRequest();

		public CalculateCallResponse CalculatedCallReponse { get; set; }

		public CalculateCall(ILogger<CalculateCall> logger)
		{
			_logger = logger;
		}

		public void OnGet()
		{
			SetPlans();
		}

		public void SetPlans()
		{
			var plans = CalculateCallHelper.GetPlans();

			foreach (var plan in plans)
			{
				string text = plan.name;
				string value = plan.id;
				PlanOptions.Add(new SelectListItem(text, value));
			}
		}

		public void OnPost()
		{
			try
			{
				CalculatedCallReponse = CalculateCallHelper.SearchPlan(CalculateCallRequest);
			}
			catch
			{
				ViewData["Error"] = "Erro ao calcular o plano =)";
			}
		}
	}
}